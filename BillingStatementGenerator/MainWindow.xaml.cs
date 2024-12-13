using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BillingStatementGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Constructors.BillingItem> newBillingItems = new List<Constructors.BillingItem>();
        public Constructors.BillingData newBillingData = new Constructors.BillingData();
        public Constructors.BillingHeader newBillingHeader = new Constructors.BillingHeader();

        private decimal _TotalAmountDue;
        public decimal TotalAmountDue
        {
            get => _TotalAmountDue;
            set
            {
                _TotalAmountDue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalAmountDue)));
            }
        }

        private Constructors.BillingItem _selectedBillingItem;
        public Constructors.BillingItem SelectedBillingItem
        {
            get => _selectedBillingItem;
            set
            {
                _selectedBillingItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBillingItem)));
            }
        }


        private string _NewItemUOM;
        public string NewItemUOM
        {
            get => _NewItemUOM;
            set
            {
                _NewItemUOM = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewItemUOM)));
            }
        }

        private string _NewItemDescription;
        public string NewItemDescription
        {
            get => _NewItemDescription;
            set
            {
                _NewItemDescription = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewItemDescription)));
            }
        }

        private string _NewItemReference;
        public string NewItemReference
        {
            get => _NewItemReference;
            set
            {
                _NewItemReference = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewItemReference)));
            }
        }

        private DateTime _NewItemDate;
        public DateTime NewItemDate
        {
            get => _NewItemDate;
            set
            {
                _NewItemDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewItemDate)));
            }
        }

        private decimal _NewItemPrice;
        public decimal NewItemPrice
        {
            get => _NewItemPrice;
            set
            {
                _NewItemPrice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewItemPrice)));
            }
        }

        private decimal _NewItemQuantity;
        public decimal NewItemQuantity
        {
            get => _NewItemQuantity;
            set
            {
                _NewItemQuantity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewItemQuantity)));
            }
        }


        private string _HeaderBiller;
        public string HeaderBiller
        {
            get => _HeaderBiller;
            set
            {
                _HeaderBiller = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBiller)));
            }
        }

        private string _HeaderBillerAddress;
        public string HeaderBillerAddress
        {
            get => _HeaderBillerAddress;
            set
            {
                _HeaderBillerAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBillerAddress)));
            }
        }

        private string _HeaderBillerContact;
        public string HeaderBillerContact
        {
            get => _HeaderBillerContact;
            set
            {
                _HeaderBillerContact = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBillerContact)));
            }
        }

        private string _HeaderBillerRemark;
        public string HeaderBillerRemark
        {
            get => _HeaderBillerRemark;
            set
            {
                _HeaderBillerRemark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBillerRemark)));
            }
        }

        private string _HeaderBillerTerm;
        public string HeaderBillerTerm
        {
            get => _HeaderBillerTerm;
            set
            {
                _HeaderBillerTerm = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBillerTerm)));
            }
        }

        private DateTime _HeaderBillDate;
        public DateTime HeaderBillDate
        {
            get => _HeaderBillDate;
            set
            {
                _HeaderBillDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBillDate)));
            }
        }

        private DateTime _HeaderBillDueDate;
        public DateTime HeaderBillDueDate
        {
            get => _HeaderBillDueDate;
            set
            {
                _HeaderBillDueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBillDueDate)));
            }
        }

        private string _HeaderCustomerName;
        public string HeaderCustomerName
        {
            get => _HeaderCustomerName;
            set
            {
                _HeaderCustomerName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderCustomerName)));
            }
        }

        private string _HeaderCustomerAddress;
        public string HeaderCustomerAddress
        {
            get => _HeaderCustomerAddress;
            set
            {
                _HeaderCustomerAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderCustomerAddress)));
            }
        }

        private string _HeaderCustomerContact;
        public string HeaderCustomerContact
        {
            get => _HeaderCustomerContact;
            set
            {
                _HeaderCustomerContact = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderCustomerContact)));
            }
        }

        private string _HeaderBillingNo;
        public string HeaderBillingNo
        {
            get => _HeaderBillingNo;
            set
            {
                _HeaderBillingNo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeaderBillingNo)));
            }
        }

        Constructors.BillerDetail myDetails = new Constructors.BillerDetail();

        public MainWindow()
        {
            InitializeComponent();

            InitializeNewItem();
            InitializeBiller();
            InitializeNewHeader();
        }

        void InitializeNewItem()
        {
            NewItemDate = DateTime.Now;
            NewItemDescription = "";
            NewItemReference = "";
            NewItemPrice = 0;
            NewItemQuantity = 0;
            NewItemUOM = "";
        }

        void InitializeNewHeader()
        {
            newBillingHeader = new();
            HeaderBillDate = DateTime.Now;
            HeaderBillDueDate = DateTime.Now.AddDays(15);
            HeaderCustomerAddress = "";
            HeaderCustomerContact = "";
            HeaderCustomerName = "";
            HeaderBillerTerm = "";
            HeaderBillerRemark = "";
            HeaderBillingNo = "";
            InitializeBiller();

        }

        void InitializeBiller()
        {
            string filePath = System.IO.Path.Combine(Globals.fn.GetDataLocation(), "\\biller.json");

            if (File.Exists(filePath))
            {

                string fileContent = File.ReadAllText(filePath);

                if (!string.IsNullOrEmpty(fileContent))
                {
                    myDetails = JsonConvert.DeserializeObject<Constructors.BillerDetail>(fileContent);

                    if(myDetails != null)
                    {
                        HeaderBillerAddress = myDetails.BillerAddress;
                        HeaderBiller = myDetails.Biller;
                        HeaderBillerContact = myDetails.BillerContact;
                    }
                }
            }
        }

        void SaveBillerName()
        {
            if (!string.IsNullOrEmpty(HeaderBiller) && !string.IsNullOrEmpty(HeaderBillerAddress) && !string.IsNullOrEmpty(HeaderBillerContact))
            {
                Constructors.BillerDetail biller = new Constructors.BillerDetail();
                biller.Biller = HeaderBiller;
                biller.BillerContact = HeaderBillerContact;
                biller.BillerAddress = HeaderBillerAddress;

                string filePath = System.IO.Path.Combine(Globals.fn.GetDataLocation(), "\\biller.json");
                if(File.Exists(filePath)) File.Delete(filePath);

                string fileContent = JsonConvert.SerializeObject(biller, Formatting.Indented);

                File.WriteAllText(filePath, fileContent);

            }

        }
        

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                if(newBillingItems != null)
                {
                    if(newBillingItems.Count > 0)
                    {
                        if(SelectedBillingItem != null)
                        {
                            var selectedItem = newBillingItems.FirstOrDefault(i => i.Id == SelectedBillingItem.Id);

                            if(selectedItem != null)
                            {
                                newBillingItems.Remove(selectedItem);
                                dgItems.ItemsSource = newBillingItems;
                            }
                        }

                    }

                }
                return;
            }
        }

        bool ValidateNewItem()
        {
            if (string.IsNullOrEmpty(NewItemDescription))
            {
                MessageBox.Show("Please input item description.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbItemDescription.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(NewItemReference))
            {
                MessageBox.Show("Please input item reference.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbItemReference.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(NewItemUOM))
            {
                MessageBox.Show("Please input item UNIT OF MEASURE (eg. PC,KG etc.).", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbItemUOM.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (NewItemPrice == 0)
            {
                MessageBox.Show("Please input item price.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbItemPrice.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (NewItemQuantity == 0)
            {
                MessageBox.Show("Please input item quantity.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbItemQuantity.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            //if(NewItemDate.ToString("MM/dd/yyyy") == "01/01/2001")
            //{
            //    MessageBox.Show("Please input item transaction date.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
            //    dtpNewItemDate.Focus();
            //    tbItemPrice.SelectAll();
            //    return false;
            //}

            return true;
        }


        bool ValidateHeaderDetails()
        {
            if (string.IsNullOrEmpty(HeaderBillingNo))
            {
                MessageBox.Show("Please input billing number / reference.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbBillingReference.Focus();
                tbItemPrice.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(HeaderCustomerName))
            {
                MessageBox.Show("Please input bill to name.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbCustomerName.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(HeaderCustomerAddress))
            {
                MessageBox.Show("Please input bill to address.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbCustomerAddress.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(HeaderCustomerContact))
            {
                MessageBox.Show("Please input bill to contact information.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbCustomerContact.Focus();
                tbItemPrice.SelectAll();
                return false;
            }


            //if (HeaderBillDate.ToString("MM/dd/yyyy") == "01/01/2001")
            //{
            //    MessageBox.Show("Please input correct billing date.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
            //    dtpBillDate.Focus();
            //    return false;
            //}

            //if (HeaderBillDueDate.ToString("MM/dd/yyyy") == "01/01/2001")
            //{
            //    MessageBox.Show("Please input correct billing due date.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
            //    dtpDueDate.Focus();
            //    return false;
            //}

            if (string.IsNullOrEmpty(HeaderBiller))
            {
                MessageBox.Show("Please input biller name.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbBillerName.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(HeaderBillerAddress))
            {
                MessageBox.Show("Please input biller address.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbBillerAddress.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(HeaderBillerContact))
            {
                MessageBox.Show("Please input biller contact information.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                tbBillerContact.Focus();
                tbItemPrice.SelectAll();
                return false;
            }

            if(HeaderBillDueDate < HeaderBillDate)
            {
                MessageBox.Show("Please input correct billing due date. Due date must be greater than billing date.", Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpDueDate.Focus();
                return false;
            }

            return true;
        }

        private void btnAddItemToBilling_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateNewItem())
            {
                int idCounter = 0;
                if(newBillingItems.Count > 0)
                {
                    idCounter = newBillingItems.Count + 1;
                }
                else
                {
                    idCounter = 1;
                }

                Constructors.BillingItem newItem = new Constructors.BillingItem();
                newItem.Description = NewItemDescription;
                newItem.Price = NewItemPrice;
                newItem.Quantity = NewItemQuantity;
                newItem.Reference = NewItemReference;
                newItem.TransDate = NewItemDate;
                newItem.Subtotal = (NewItemQuantity * NewItemPrice);
                newItem.UOM = NewItemUOM;
                newItem.Id = idCounter;

                if(newItem != null)
                {
                    newBillingItems.Add(newItem);

                    if(newBillingItems.Count > 0)
                    {
                        RecomputeTotal();
                    }

                    MessageBox.Show("Item Successfully Add See List Below", Globals.MODULE_NAME, MessageBoxButton.OK);

                    InitializeNewItem();
                }

            }

            RecomputeTotal();
        }

        private void RecomputeTotal()
        {
            if(newBillingItems != null)
            {
                if (newBillingItems.Count > 0)
                {
                    TotalAmountDue = newBillingItems.Sum(i => i.Subtotal);

                    if(newBillingHeader != null)
                        newBillingHeader.BillingAmountDue = TotalAmountDue;
                }
                else
                {
                    TotalAmountDue = 0;
                }


            }
            else
            {
                TotalAmountDue = 0;
            }

            dgItems.ItemsSource = null;
            dgItems.ItemsSource = newBillingItems;
        }

        private void btnSaveHeader_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateHeaderDetails())
            {
                newBillingHeader.CompanyName = HeaderBiller;
                newBillingHeader.CompanyContact = HeaderBillerContact;
                newBillingHeader.CompanyAddress = HeaderBillerAddress;
                newBillingHeader.BillingTerms = HeaderBillerTerm;
                newBillingHeader.BillingReference = HeaderBillingNo;
                newBillingHeader.BillingDueDate = HeaderBillDueDate;
                newBillingHeader.BillingDate = HeaderBillDate;
                newBillingHeader.CustomerName = HeaderCustomerName;
                newBillingHeader.CustomerContact = HeaderCustomerContact;
                newBillingHeader.CustomerAddress = HeaderCustomerAddress;
                newBillingHeader.BillingRemarks = HeaderBillerRemark;
                newBillingHeader.BillingAmountDue = TotalAmountDue;

                MessageBox.Show("Header Details Successfully Saved", Globals.MODULE_NAME, MessageBoxButton.OK);
            }
        }

        void ProcessLogoImage()
        {
            string billingFileImage = System.IO.Path.Combine(Globals.fn.GetDataBillingsLocation(), "logo.png.jpg");
            string logoImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.png.jpg");

            if (File.Exists(logoImage))
            {
                if (File.Exists(billingFileImage))
                {
                    File.Delete(billingFileImage);
                }
                File.Copy(logoImage, billingFileImage);
            }
        }

        private void btnSavePrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newBillingData = new();
                if (newBillingHeader != null && newBillingItems != null)
                {
                    if (newBillingItems.Count == 0)
                    {
                        MessageBox.Show("Please add item to bill.", Globals.MODULE_NAME); return;
                    }

                    newBillingData.header = newBillingHeader;
                    newBillingData.items = newBillingItems;

                    string billingFile = System.IO.Path.Combine(Globals.fn.GetDataBillingsLocation(), newBillingHeader.BillingReference + ".json");
                    
                    if (File.Exists(billingFile)) File.Delete(billingFile);
                    ProcessLogoImage();
                    string billingData = JsonConvert.SerializeObject(newBillingData);

                    File.WriteAllText(billingFile, billingData);
                    string billingFormat = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kfpt billing format.html");
                    if (File.Exists(billingFormat))
                    {
                        string newFileFormat = System.IO.Path.Combine(Globals.fn.GetDataBillingsLocation(), newBillingHeader.BillingReference + ".html");

                        if (File.Exists(newFileFormat)) File.Delete(newFileFormat);
                        else File.Copy(billingFormat, newFileFormat);

                        if (File.Exists(newFileFormat))
                        {
                            string formatContent = File.ReadAllText(newFileFormat);
                            string newFileContent = formatContent;

                            newFileContent = newFileContent.Replace("[BillerName]", " " + newBillingHeader.CompanyName);
                            newFileContent = newFileContent.Replace("[BillerAddress]", " " + newBillingHeader.CompanyAddress);
                            newFileContent = newFileContent.Replace("[BillerContact]", " " + newBillingHeader.CompanyContact);
                            newFileContent = newFileContent.Replace("[BillingNo]", " " + newBillingHeader.BillingReference);
                            newFileContent = newFileContent.Replace("[BillingDate]", " " + newBillingHeader.BillingDate.ToString("MM/dd/yyyy"));
                            newFileContent = newFileContent.Replace("[BillingDueDate]", " " + newBillingHeader.BillingDueDate.ToString("MM/dd/yyyy"));
                            newFileContent = newFileContent.Replace("[BillingRemark]", " " + newBillingHeader.BillingRemarks);
                            newFileContent = newFileContent.Replace("[AmountDue]", " " + newBillingHeader.BillingAmountDue.ToString("0.00"));
                            newFileContent = newFileContent.Replace("[CustomerName]", " " + newBillingHeader.CustomerName);
                            newFileContent = newFileContent.Replace("[CustomerAddress]", " " + newBillingHeader.CustomerAddress);
                            newFileContent = newFileContent.Replace("[CustomerContact]"," "+ newBillingHeader.CustomerContact);


                            string itemDetails = "";
                            foreach (var item in newBillingItems)
                            {
                                //guide
                                //< tr class="item">
                                //	<td>1</td>
                                //	<td>Reference</td>
                                //	<td>Description</td>
                                //	<td>Date</td>
                                //	<td>Price</td>
                                //	<td>Quantity</td>
                                //	<td>UOM</td>
                                //	<td>$300.00</td>
                                //</tr>

                                itemDetails += "\n<tr class=\"item\">";
                                itemDetails += "\n\t<td>" + item.Id + "</td>";
                                itemDetails += "\n\t<td>" + item.Reference + "</td>";
                                itemDetails += "\n\t<td>" + item.Description + "</td>";
                                itemDetails += "\n\t<td>" + item.TransDate.ToString("MM/dd/yyyy") + "</td>";
                                itemDetails += "\n\t<td>" + item.Price + "</td>";
                                itemDetails += "\n\t<td>" + item.Quantity + "</td>";
                                itemDetails += "\n\t<td>" + item.UOM + "</td>";
                                itemDetails += "\n\t<td>" + item.Subtotal.ToString("#,##0.00") + "</td>";
                                itemDetails += "\n</tr>";
                                itemDetails += "\n";
                            }

                            if (!string.IsNullOrEmpty(itemDetails))
                            {
                                newFileContent = newFileContent.Replace("<!--REPLACEME-->", itemDetails);
                            }

                            if (!string.IsNullOrEmpty(newFileContent))
                            {
                                File.WriteAllText(newFileFormat, newFileContent);
                                //Uri htmlFile = new Uri(newFileFormat);
                                //System.Diagnostics.Process.Start(newFileFormat);
                                //MessageBox.Show("Get file in this location " + newFileFormat, Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Information);

                                var p = new Process();
                                p.StartInfo = new ProcessStartInfo(newFileFormat)
                                {
                                    UseShellExecute = true
                                };
                                p.Start();
                                MessageBox.Show("Done generating billing document see browser window or check in this location " + newFileFormat, Globals.MODULE_NAME, MessageBoxButton.OK, MessageBoxImage.Information);
                                //await new BrowserFetcher().DownloadAsync();
                                //using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
                                //var page = await browser.NewPageAsync();

                                //await page.GoToAsync(newFileContent);
                                //await page.PdfAsync(newBillingHeader.BillingReference +".pdf");
                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                string errorMessage = "error: " + ex.Message + "\n stack:" + ex.StackTrace;
                MessageBox.Show(errorMessage,Globals.MODULE_NAME, MessageBoxButton.OK,MessageBoxImage.Error);
                throw;
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            InitializeNewItem();
            InitializeNewHeader();
            newBillingItems = new();
            dgItems.ItemsSource = newBillingItems;
        }

        private void tbItemUOM_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnAddItemToBilling_Click(sender, e);
            }

        }

        private void tbBillRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSaveHeader_Click(sender, e);
            }
        }
    }
}