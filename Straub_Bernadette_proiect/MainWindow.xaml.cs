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
using System.ComponentModel;

namespace Straub_Bernadette_proiect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //creare obiect binding pentru comanda
            CommandBinding cmd1 = new CommandBinding();
            //asociere comanda
            cmd1.Command = ApplicationCommands.Print;
            //input gesture: I + Alt
            ApplicationCommands.Print.InputGestures.Add(new KeyGesture(Key.I, ModifierKeys.Alt));
            //asociem un handler
            cmd1.Executed += new ExecutedRoutedEventHandler(CtrlP_CommandHandler);
            //adaugam la colectia CommandBindings
            CommandBindings.Add(cmd1);

            //Dishes>Stop
            //comanda custom
            CommandBinding cmd2 = new CommandBinding();
            cmd2.Command = CustomCommands.StopCommand.Launch;
            cmd2.Executed += new
            ExecutedRoutedEventHandler(CtrlS_CommandHandler);//asociem handler
            CommandBindings.Add(cmd2);
        }

        private void CtrlS_CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            //handler pentru comanda Ctrl+S -> se va executa stopToolStripMenuItem_Click
            MessageBox.Show("Ctrl+S was pressed! The kitchen staff will stop preparing dishes!");
            this.stopToolStripMenuItem_Click(sender, e);
        }

        private void CtrlP_CommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("You have in stock:" + mPastaBolognese + " Bolognese," + mPastaCarbonara + " Carbonara," + mPastaPesto + " Pesto, " + mPizzaMargherita + " Margherita, " + mPizzaTonno + " Tonno, " + mPizzaDiavola + " Diavola, " + mDessertGelato + " Gelato, " + mDessertTiramisu + " Tiramisu "
           );
        }

        private void btnAddToSale_Click(object sender, RoutedEventArgs e)
        {
        }

        private KitchenStaff myKitchenStaff;

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myKitchenStaff = new KitchenStaff();
            myKitchenStaff.DishComplete += new KitchenStaff.DishCompleteDelegate(DishCompleteHandler);
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }

        private int mPastaBolognese;
        private int mPastaCarbonara;
        private int mPastaPesto;
        private int mPizzaMargherita;
        private int mPizzaTonno;
        private int mPizzaDiavola;
        private int mDessertGelato;
        private int mDessertTiramisu;

        //PASTA
        private void bologneseToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            bologneseMenuItem.IsChecked = true;
            carbonaraMenuItem.IsChecked = false;
            pestoMenuItem.IsChecked = false;
            myKitchenStaff.PrepareDishes(DishType.Bolognese);
        }
        private void carbonaraToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            bologneseMenuItem.IsChecked = false;
            carbonaraMenuItem.IsChecked = true;
            pestoMenuItem.IsChecked = false;
            myKitchenStaff.PrepareDishes(DishType.Carbonara);
        }

        private void pestoToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            bologneseMenuItem.IsChecked = false;
            carbonaraMenuItem.IsChecked = false;
            pestoMenuItem.IsChecked = true;
            myKitchenStaff.PrepareDishes(DishType.Pesto);
        }

        //PIZZA
        private void margheritaToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            margheritaMenuItem.IsChecked = true;
            tonnoMenuItem.IsChecked = false;
            diavolaMenuItem.IsChecked = false;
            myKitchenStaff.PrepareDishes(DishType.Margherita);
        }

        private void tonnoToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            margheritaMenuItem.IsChecked = false;
            tonnoMenuItem.IsChecked = true;
            diavolaMenuItem.IsChecked = false;
            myKitchenStaff.PrepareDishes(DishType.Tonno);
        }

        private void diavolaToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            margheritaMenuItem.IsChecked = false;
            tonnoMenuItem.IsChecked = false;
            diavolaMenuItem.IsChecked = true;
            myKitchenStaff.PrepareDishes(DishType.Diavola);
        }

        //DESSERT
        private void gelatoToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            gelatoMenuItem.IsChecked = true;
            tiramisuMenuItem.IsChecked = false;
            myKitchenStaff.PrepareDishes(DishType.Gelato);
        }

        private void tiramisuToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            gelatoMenuItem.IsChecked = false;
            tiramisuMenuItem.IsChecked = true;
            myKitchenStaff.PrepareDishes(DishType.Tiramisu);
        }

        private void DishCompleteHandler()
        {
            switch (myKitchenStaff.DishType)
            {
                case DishType.Bolognese:
                    mPastaBolognese++;
                    txtBolognese.Text = mPastaBolognese.ToString();
                    break;

                case DishType.Carbonara:
                    mPastaCarbonara++;
                    txtCarbonara.Text = mPastaCarbonara.ToString();
                    break;

                case DishType.Pesto:
                    mPastaPesto++;
                    txtPesto.Text = mPastaPesto.ToString();
                    break;

                case DishType.Margherita:
                    mPizzaMargherita++;
                    txtMargherita.Text = mPizzaMargherita.ToString();
                    break;

                case DishType.Tonno:
                    mPizzaTonno++;
                    txtTonno.Text = mPizzaTonno.ToString();
                    break;

                case DishType.Diavola:
                    mPizzaDiavola++;
                    txtDiavola.Text = mPizzaDiavola.ToString();
                    break;

                case DishType.Gelato:
                    mDessertGelato++;
                    txtGelato.Text = mDessertGelato.ToString();
                    break;

                case DishType.Tiramisu:
                    mDessertTiramisu++;
                    txtTiramisu.Text = mDessertTiramisu.ToString();
                    break;

            }

        }

        private void MenuItems_Click(object sender, RoutedEventArgs e)
        {
            string DishType;

            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            DishType = SelectedItem.Header.ToString();
            Enum.TryParse(DishType, out DishType dishType);
            myKitchenStaff.PrepareDishes(dishType);

        }

        private void MenuItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " dishes are being prepared!";
            this.Title = mesaj;
        }

        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myKitchenStaff.Enabled = false;
            this.Title = "Virtual Italian Restaurant";
            e.Handled = true;
        }
        private void exitToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        KeyValuePair<DishType, double>[] PriceList = {
        new KeyValuePair<DishType, double>(DishType.Bolognese, 7.5),
        new KeyValuePair<DishType, double>(DishType.Carbonara, 7),
        new KeyValuePair<DishType, double>(DishType.Pesto,6.5),
        new KeyValuePair<DishType, double>(DishType.Margherita,7),
        new KeyValuePair<DishType, double>(DishType.Tonno,9.5),
        new KeyValuePair<DishType, double>(DishType.Diavola,9.5),
        new KeyValuePair<DishType, double>(DishType.Gelato,3.5),
        new KeyValuePair<DishType, double>(DishType.Tiramisu,4.5)
        };

        DishType selectedDish;

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<DishType, double> selectedEntry =
           (KeyValuePair<DishType, double>)cmbType.SelectedItem;
            selectedDish = selectedEntry.Key;
        }

        private int ValidateQuantity(DishType selectedDoughnut)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedDoughnut)
            {
                case DishType.Bolognese:
                    if (q > mPastaBolognese)
                        r = 0;
                    break;
                case DishType.Carbonara:
                    if (q > mPastaCarbonara)
                        r = 0;
                    break;
                case DishType.Pesto:
                    if (q > mPastaPesto)
                        r = 0;
                    break;
                case DishType.Margherita:
                    if (q > mPizzaMargherita)
                        r = 0;
                    break;
                case DishType.Tonno:
                    if (q > mPizzaTonno)
                        r = 0;
                    break;
                case DishType.Diavola:
                    if (q > mPizzaDiavola)
                        r = 0;
                    break;
                case DishType.Gelato:
                    if (q > mDessertGelato)
                        r = 0;
                    break;
                case DishType.Tiramisu:
                    if (q > mDessertTiramisu)
                        r = 0;
                    break;
            }
            return r;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedDish) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedDish.ToString() +
               ":" + txtPrice.Text + " " + double.Parse(txtQuantity.Text) *
               double.Parse(txtPrice.Text));
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = (double.Parse(txtTotal.Text) + double.Parse(txtQuantity.Text)
           * double.Parse(txtPrice.Text)).ToString();
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
               1))
                {
                    case "Bolognese":
                        mPastaBolognese = mPastaBolognese - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBolognese.Text = mPastaBolognese.ToString();
                        break;
                    case "Carbonara":
                        mPastaCarbonara = mPastaCarbonara - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtCarbonara.Text = mPastaCarbonara.ToString();
                        break;
                    case "Pesto":
                        mPastaPesto = mPastaPesto - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtPesto.Text = mPastaPesto.ToString();
                        break;
                    case "Margherita":
                        mPizzaMargherita = mPizzaMargherita - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtMargherita.Text = mPizzaMargherita.ToString();
                        break;
                    case "Tonno":
                        mPizzaTonno = mPizzaTonno - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtTonno.Text = mPizzaTonno.ToString();
                        break;
                    case "Diavola":
                        mPizzaDiavola = mPizzaDiavola - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtDiavola.Text = mPizzaDiavola.ToString();
                        break;
                    case "Gelato":
                        mDessertGelato = mDessertGelato - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtGelato.Text = mDessertGelato.ToString();
                        break;
                    case "Tiramisu":
                        mDessertTiramisu = mDessertTiramisu - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtTiramisu.Text = mDessertTiramisu.ToString();
                        break;
                }
            }
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
