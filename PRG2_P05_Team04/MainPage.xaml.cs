using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PRG2_P05_Team04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Items lists
        List<MenuItem> MenuList = new List<MenuItem>();
        List<Sides> SideList = new List<Sides>();
        List<Beverages> BeverageList = new List<Beverages>();
        List<ValueMeal> ValueList = new List<ValueMeal>();

        //Display
        List<MenuItem> Menulistdisplay = new List<MenuItem>();
        List<MenuItem> Menulistdisplay2 = new List<MenuItem>();

        //Order
        List<OrderItem> OrderList = new List<OrderItem>();
        List<Order> ReceiptList = new List<Order>();

        //Add Order List
        List<MenuItem> AddOrderList = new List<MenuItem>();

        //Update List with beverage
        List<Beverages> Newlist = new List<Beverages>();

        //BreakFast set with no drink offered
        List<OrderItem> Breakfast = new List<OrderItem>();

        void InitData()
        {
            //Menu List Bundle
            MenuItem m1 = new MenuItem("Breakfast set \n(Hotcake with sausage, Hash Brown)", 7.90);
            MenuItem m2 = new MenuItem("Hamburger combo \n(Hamgurger, Fries, Cola)", 10.20);
            MenuItem m3 = new MenuItem("Dinner set \n(Ribeye steak, Fries, Caesar, Salad, Coffee)", 18.50);

            MenuList.Add(m1);
            MenuList.Add(m2);
            MenuList.Add(m3);

            //Side List
            Sides s1 = new Sides("Hash Brown", 2.10);
            Sides s2 = new Sides("Truffle fries", 3.70);
            Sides s3 = new Sides("Calamari", 3.40);
            Sides s4 = new Sides("Caesar Salad", 4.30);

            SideList.Add(s1);
            SideList.Add(s2);
            SideList.Add(s3);
            SideList.Add(s4);

            //Beverage List
            Beverages b1 = new Beverages("Cola", 2.85, 2.85);
            Beverages b2 = new Beverages("Green Tea", 3.70, 2.85);
            Beverages b3 = new Beverages("Coffee", 2.70, 2.85);
            Beverages b4 = new Beverages("Tea", 2.70, 2.85);
            Beverages b5 = new Beverages("Tom's Root Beer", 9.70, 2.85);
            Beverages b6 = new Beverages("Mocktail", 15.90, 2.85);

            BeverageList.Add(b1);
            BeverageList.Add(b2);
            BeverageList.Add(b3);
            BeverageList.Add(b4);
            BeverageList.Add(b5);
            BeverageList.Add(b6);

            //ValueMeal List
            DateTime starttime1 = new DateTime(2018, 1, 1, 07, 00, 00);
            DateTime endtime1 = new DateTime(2018, 12, 31, 14, 00, 00);
            ValueMeal v1 = new ValueMeal("Hotcake with sausage", 6.90, starttime1, endtime1);

            DateTime starttime2 = new DateTime(2018, 1, 1, 10, 00, 00);
            DateTime endtime2 = new DateTime(2018, 12, 31, 19, 00, 00);
            ValueMeal v2 = new ValueMeal("Hamburger", 7.50, starttime2, endtime2);


            DateTime starttime3 = new DateTime(2018, 1, 1, 16, 00, 00);
            DateTime endtime3 = new DateTime(2018, 12, 31, 22, 00, 00);
            ValueMeal v3 = new ValueMeal("Ribeye steak", 10.20, starttime3, endtime3);

            DateTime starttime4 = new DateTime(2018, 1, 1, 00, 00, 00);
            DateTime endtime4 = new DateTime(2018, 12, 31, 23, 59, 59);
            ValueMeal v4 = new ValueMeal("Nasi Lemak", 5.40, starttime4, endtime4);

            ValueList.Add(v1);
            ValueList.Add(v2);
            ValueList.Add(v3);
            ValueList.Add(v4);

            m1.ProductList.Add(v1);
            m1.ProductList.Add(s1);

            m2.ProductList.Add(v2);
            m2.ProductList.Add(s2);
            m2.ProductList.Add(b1);

            m3.ProductList.Add(v3);
            m3.ProductList.Add(s2);
            m3.ProductList.Add(s4);
            m3.ProductList.Add(b3);

            Order CustomerOrder = new Order();
            ReceiptList.Add(CustomerOrder);

            OrderItem BreakfastSet = new OrderItem(m1);
            Breakfast.Add(BreakfastSet);
        }

        public MainPage()
        {
            this.InitializeComponent();
            InitData();
        }

        private void btnBundle_Click(object sender, RoutedEventArgs e)
        {
            Menulistdisplay2.Clear();
            foreach (MenuItem M in MenuList)
            {
                foreach (Product P in M.ProductList)
                {
                    if (P is ValueMeal)
                    {
                        ValueMeal V = (ValueMeal)P;
                        if (V.IsAvailable())
                        {
                            Menulistdisplay2.Add(M);
                            //list display
                        }
                    }
                }
            }
            lvMenu.ItemsSource = null;
            lvMenu.ItemsSource = Menulistdisplay2;
            Recepittxt.Text = "\nWelcome to Tom's Cafe!\n" +
    "\nChoose your item from the menu. ";
        }

        private void btnsides_Click(object sender, RoutedEventArgs e)
        {
            Menulistdisplay.Clear();
            foreach (Sides s in SideList)
            {
                MenuItem side = new MenuItem(s.Name, s.Price);
                Menulistdisplay.Add(side);
            }
            lvMenu.ItemsSource = null;
            lvMenu.ItemsSource = Menulistdisplay;
            Recepittxt.Text = "\nWelcome to Tom's Cafe!\n" +
    "\nChoose your item from the menu. ";
        }

        private void btnvaluemeal_Click(object sender, RoutedEventArgs e)
        {
            Menulistdisplay.Clear();
            foreach (ValueMeal v in ValueList)
            {
                if (v.IsAvailable())
                {
                    MenuItem ValueMeal = new MenuItem(v.Name, v.Price);
                    Menulistdisplay.Add(ValueMeal);
                }
            }
            lvMenu.ItemsSource = null;
            lvMenu.ItemsSource = Menulistdisplay;
            Recepittxt.Text = "\nWelcome to Tom's Cafe!\n" +
    "\nChoose your item from the menu. ";
        }

        private void btnbeverages_Click(object sender, RoutedEventArgs e)
        {
            Menulistdisplay.Clear();
            foreach (Beverages b in BeverageList)
            {
                MenuItem beverage = new MenuItem(b.Name, b.Price);
                Menulistdisplay.Add(beverage);
            }
            lvMenu.ItemsSource = null;
            lvMenu.ItemsSource = Menulistdisplay;
            Recepittxt.Text = "\nWelcome to Tom's Cafe!\n" +
    "\nChoose your item from the menu. ";
        }

        //Add Cart Button for value, side, beverage
        void AddCartButton()
        {

            int n = 1;
            foreach (MenuItem Order in Menulistdisplay)
            {
                if (lvMenu.SelectedItem is null)
                {
                    //null
                    continue;
                }

                //Only Value, Sides and Beverages in Menu list
                if (Order.ToString() == lvMenu.SelectedItem.ToString())
                {
                    if (OrderList.Count > 0)
                    {
                        foreach (OrderItem OT in OrderList)
                        {
                            //Quantity
                            if (Order.Name == OT.Item.Name)
                            {
                                OT.Quantity += 1;
                                n = 0;
                                Recepittxt.Text = OT.Item.Name + " added. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                                Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
    "\nChoose your item from the menu. ";
                                break;
                            }
                        }

                        //Add Quantity
                        if (n == 1)
                        {
                            OrderItem another = new OrderItem(Order);
                            another.Quantity = 1;

                            OrderList.Add(another);
                            Recepittxt.Text = another.Item.Name + " added. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                            Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
    "\nChoose your item from the menu. ";
                            break;
                        }


                    }
                    else
                    {
                        OrderItem another = new OrderItem(Order);
                        another.Quantity = 1;
                        OrderList.Add(another);
                        Recepittxt.Text = another.Item.Name + " added. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                        Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
    "\nChoose your item from the menu. ";
                    }
                }
            }
        }

        //Calculate Total Cost for OrderList
        public double CalculateTotalCost()
        {
            double cost = 0;
            foreach (OrderItem OT in OrderList)
            {
                cost += OT.GetItemTotalAmt();
            }
            return cost;
        }

        private void btnremove_Click(object sender, RoutedEventArgs e)
        {
            int s = 0;
            if (OrderList.Count > 0)
            {
                foreach (OrderItem o in OrderList)
                {
                    if (cartlistview.SelectedItem is null)
                    {
                        Recepittxt.Text = "No Item Selected.\n";
                        Recepittxt.Text += "\nWelcome to Tom's Cafe!\n\nChoose your item from the menu. ";
                        continue;
                    }
                    if (o.ToString() == cartlistview.SelectedItem.ToString())
                    {

                        foreach (OrderItem p in OrderList)
                        {
                            if (p.ToString() == cartlistview.SelectedItem.ToString())
                            {
                                if (p.Quantity == 1)
                                {
                                    s = 1;
                                    Recepittxt.Text = p.Item.Name + " has been removed. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                                    Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
                "\nChoose your item from the menu. ";
                                    break;
                                }
                                else
                                {
                                    o.Quantity = o.Quantity - 1;
                                    Recepittxt.Text = p.Item.Name + " has been removed. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                                    Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
                "\nChoose your item from the menu. ";
                                }
                            }

                        }
                        if (s == 1)
                        {
                            OrderList.Remove(o);
                            cartlistview.ItemsSource = null;
                            cartlistview.ItemsSource = OrderList;
                            Recepittxt.Text = o.Item.Name + " has been removed. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                            Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
        "\nChoose your item from the menu. ";
                            break;
                        }
                    }


                }
                cartlistview.ItemsSource = null;
                cartlistview.ItemsSource = OrderList;
            }
            else
            {
                Recepittxt.Text = "There is nothing in your cart.\n";
                Recepittxt.Text += "\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.";
            }
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            MenuItem selected = (MenuItem)lvMenu.SelectedItem;
            OrderItem Selected = new OrderItem(selected);
            if (lvMenu.ItemsSource == Menulistdisplay)
            {
                //for value,bever,side
                AddCartButton();
                cartlistview.ItemsSource = null;
                cartlistview.ItemsSource = OrderList;
            }

            //bundle meal
            else if (lvMenu.ItemsSource == Menulistdisplay2)
            {
                int n = 1;
                foreach (MenuItem Order in Menulistdisplay2)
                {
                    if (lvMenu.SelectedItem is null)
                    {
                        //null
                        continue;
                    }

                    if (Order.ToString() == lvMenu.SelectedItem.ToString())
                    {
                        if (OrderList.Count > 0)
                        {
                            foreach (OrderItem P in OrderList) //[breakfast, hamburgeer]
                            {
                                if (Selected.Item == P.Item)
                                {
                                    P.AddQty();
                                    n = 0;
                                    Recepittxt.Text = P.Item.Name + " added. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                                    Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
                "\nChoose your item from the menu. ";
                                    break;

                                }

                            }
                            if (n == 1)
                            {
                                //item from menuitem class, and then but it cannt put into orderitem class
                                OrderItem yoyo = new OrderItem(Order);
                                yoyo.Quantity = 1;
                                OrderList.Add(yoyo);
                                Recepittxt.Text = yoyo.Item.Name + " added. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                                Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
            "\nChoose your item from the menu. ";
                                break;
                            }
                        }
                        else
                        {
                            OrderItem yoyo = new OrderItem(Order);
                            yoyo.Quantity = 1;
                            OrderList.Add(yoyo);
                            Recepittxt.Text = yoyo.Item.Name + " added. \nTotal: $" + CalculateTotalCost().ToString("0.00");
                            Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
        "\nChoose your item from the menu. ";
                        }

                    }

                }
                cartlistview.ItemsSource = null;
                cartlistview.ItemsSource = OrderList;
            }
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            if (OrderList.Count > 0)
            {
                OrderList.Clear();
                Recepittxt.Text = "Your order is cancelled.";
                Recepittxt.Text += "\n\nWelcome to Tom's Cafe!\n" +
                    "\nChoose your item from the menu. ";

                cartlistview.ItemsSource = null;
                cartlistview.ItemsSource = OrderList;
            }

            else
            {
                Recepittxt.Text = "There is nothing in your cart.\n" +
                    "\nWelcome to Tom'sCafe!\n" +
                    "\nChoose your item from the menu.";
            }
        }

        private void btnconfirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (Order o in ReceiptList)
            {
                o.ItemList = OrderList;

                Recepittxt.Text = o.ToString();

                Menulistdisplay.Clear();
                Menulistdisplay2.Clear();
                OrderList.Clear();

                cartlistview.ItemsSource = null;
                cartlistview.ItemsSource = OrderList;

                lvMenu.ItemsSource = null;
                lvMenu.ItemsSource = Menulistdisplay;

                lvMenu.ItemsSource = null;
                lvMenu.ItemsSource = Menulistdisplay2;
            }
        }
    }
}
