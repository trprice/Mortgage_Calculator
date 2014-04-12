using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mortgage_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class ResultsItem
    {
        public String year { get; set; }
        public String payment { get; set; }
        public String endingBalance { get; set; }
        public String principalPaid { get; set; }
        public String interestPaid { get; set; }
    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Setup the DataGrid
            DataGridTextColumn yearCol = new DataGridTextColumn();
            DataGridTextColumn paymentCol = new DataGridTextColumn();
            DataGridTextColumn endingBalanceCol = new DataGridTextColumn();
            DataGridTextColumn principalPaidCol = new DataGridTextColumn();
            DataGridTextColumn interestPaidCol = new DataGridTextColumn();

            Results.Columns.Add(yearCol);
            Results.Columns.Add(paymentCol);
            Results.Columns.Add(endingBalanceCol);
            Results.Columns.Add(principalPaidCol);
            Results.Columns.Add(interestPaidCol);

            yearCol.Binding = new Binding("year");
            paymentCol.Binding = new Binding("payment");
            endingBalanceCol.Binding = new Binding("endingBalance");
            principalPaidCol.Binding = new Binding("principalPaid");
            interestPaidCol.Binding = new Binding("interestPaid");

            yearCol.Header = "Year";
            paymentCol.Header = "Payment";
            endingBalanceCol.Header = "EndingBalance";
            principalPaidCol.Header = "PrincipalPaid";
            interestPaidCol.Header = "InterestPaid";

            Results.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        }

        private void NearestCents(object sender, RoutedEventArgs e)
        {
            ComputePayments(2);
        }

        private void NearestDollars(object sender, RoutedEventArgs e)
        {
            ComputePayments(0);
        }

        private void ComputePayments (int numberOfDecimals)
        {
            // Get the items from the screen.
            double principal = Convert.ToDouble(this.loanAmountTextBox.GetLineText(0));
            Int32 years = Convert.ToInt32(this.loanPeriodTextBox.GetLineText(0));
            double apr = Convert.ToDouble(this.APRTextBox.GetLineText(0));
            double monthlyRate;
            double monthlyPayment;
            double balance;
            double principalPaid,
                   interestPaid,
                   onePlusMonthlyRateToTheEndingMonth;
            Int32 numberOfPayments;

            // If we have rows, clean them out so that we only end up with the newly computed rows
            if (this.Results.HasItems)
                this.Results.Items.Clear();

            // Compute the intermediate values that will be helpful to have.
            monthlyRate = apr / 12 / 100;
            numberOfPayments = years * 12;

            // The formula for the monthly payment, as given by http://en.wikipedia.org/wiki/Mortgage_calculator is:
            monthlyPayment = (monthlyRate * principal) / (1 - Math.Pow((1 + monthlyRate), (-1 * numberOfPayments)));

            // Initialize Balance
            balance = principal;
            
            // Add the items to the DataGrid
            for (int i = 0; i < years; i++)
            {
                // Go from 1 to 12 instead of 0 to 11 to make the number of months correct in the calulation below.
                principalPaid = 0.0;
                interestPaid = 0.0;

                for (int j = 1; j <= 12; j++)
                {
                    // Interest on the previous balance is interest due this time around.
                    double currentInterest = balance * monthlyRate;
                    interestPaid += currentInterest;
                    principalPaid += monthlyPayment - currentInterest;
                   
                    // Compute the ending balance as of i years * j (months)
                    //      - At the end of the loop this will be the ending balance for the year
                    int endingMonth = ((i * 12) + j);
                    onePlusMonthlyRateToTheEndingMonth = Math.Pow((1 + monthlyRate), endingMonth);
                    balance = (onePlusMonthlyRateToTheEndingMonth * principal) - (((onePlusMonthlyRateToTheEndingMonth - 1) / monthlyRate) * monthlyPayment);
                }

                this.Results.Items.Add(new ResultsItem { year = (i + 1).ToString(),
                                                         payment = Math.Round(monthlyPayment, numberOfDecimals).ToString(),
                                                         endingBalance = Math.Round(balance, numberOfDecimals).ToString(),
                                                         interestPaid = Math.Round(interestPaid, numberOfDecimals).ToString(),
                                                         principalPaid = Math.Round(principalPaid, numberOfDecimals).ToString()
                });
            }
        }
    }
}
