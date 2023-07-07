using ExpenseTracking.Core.ServiceContracts;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.RepositoryContracts;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ExpenseTracking.Core.Services
{
    public class ReportService(IUserRepository userRepository, ITransactionRepository transactionRepository, IEmailAttachmentSender emailSender) : IReportService
    {
        private async Task<Stream> GenerateReportXML(IEnumerable<Transaction> transactions)
        {
            MemoryStream stream = new();
            using (ExcelPackage excelPackage = new(stream))
            {
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets.Add("Transactions");
                workSheet.Cells["A1"].Value = nameof(Transaction.Id);
                workSheet.Cells["B1"].Value = nameof(Transaction.Date);
                workSheet.Cells["C1"].Value = nameof(Transaction.Amount);
                workSheet.Cells["D1"].Value = nameof(Transaction.Description);
                using (ExcelRange headerCells = workSheet.Cells["A1:D1"])
                {
                    headerCells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headerCells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    headerCells.Style.Font.Bold = true;
                }
                int row = 2;
                foreach (var transaction in transactions)
                {
                    workSheet.Cells[row, 1].Value = transaction.Id;
                    workSheet.Cells[row, 2].Value = transaction.Date.ToString("G");
                    workSheet.Cells[row, 3].Value = transaction.Amount;
                    workSheet.Cells[row, 4].Value = transaction.Description;
                    row++;
                }
                workSheet.Cells[$"A1:H{row}"].AutoFitColumns();

                await excelPackage.SaveAsync();
            }
            stream.Position = 0;
            return stream;

        }

        public async Task SendDailyReports()
        {
            var users = await userRepository.GetAllAsync(r => r.ReceiveDailyReports == true);
            foreach (var user in users)
            {
                var transactions = await transactionRepository.GetAllAsync(t => t.UserId == user.Id && t.Date > DateTime.Now.AddDays(-1));
                var report = await GenerateReportXML(transactions);
                await emailSender.SendEmailAsync(user.Email, "Bies Expense Tracking - Daily Report", "Here is your daily transaction report", report, $"Daily Report - {DateTime.Now.AddDays(-1):d}.xlsx");
            }
        }
        public async Task SendWeeklyReports()
        {
            var users = await userRepository.GetAllAsync(r => r.ReceiveWeeklyReports == true);
            foreach (var user in users)
            {
                var transactions = await transactionRepository.GetAllAsync(t => t.UserId == user.Id && t.Date > DateTime.Now.AddDays(-7));
                var report = await GenerateReportXML(transactions);
                await emailSender.SendEmailAsync(user.Email, "Bies Expense Tracking - Weekly Report", "Here is your weekly transaction report", report, $"Weekly Report - {DateTime.Now.AddDays(-1):d}.xlsx");
            }
        }
        public async Task SendMonthlyReports()
        {
            var daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            var users = await userRepository.GetAllAsync(r => r.ReceiveMonthlyReports == true);
            foreach (var user in users)
            {
                var transactions = await transactionRepository.GetAllAsync(t => t.UserId == user.Id && t.Date > DateTime.Now.AddDays(-daysInMonth));
                var report = await GenerateReportXML(transactions);
                await emailSender.SendEmailAsync(user.Email, "Bies Expense Tracking - Monthly Report", "Here is your monthly transaction report", report, $"Monthly Report - {DateTime.Now.AddDays(-1):d}.xlsx");
            }
        }
    }
}
