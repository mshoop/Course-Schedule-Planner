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
using System.Collections;

namespace WeeklyScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            addRowsToDataGrid();
            IntItData();
        }

        public class DaysOfWeek
        {
            public string monday { get; set; }
            public string tuesday { get; set; }
            public string wednesday { get; set; }
            public string thursday { get; set; }
            public string friday { get; set; }
        }

        private void addRowsToDataGrid()
        {
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            // undo not implemented
        }

        private void redoButton_Click(object sender, RoutedEventArgs e)
        {
            // redo not implemented
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            class1Menu.SelectedIndex = 0;
            class2Menu.SelectedIndex = 0;
            class3Menu.SelectedIndex = 0;
            class4Menu.SelectedIndex = 0;
            class5Menu.SelectedIndex = 0;
        }

        private void showOnlyOpenSectionsButton_Click(object sender, RoutedEventArgs e)
        {
            // probably don't need, assume...
        }

        // Class 1 combo box changing
        private void class1Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (class1Menu.SelectedIndex)
            {
                case -1: 
                case 0:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("CptS 423",new ArrayList()))]); break;
                case 1:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("CptS 423", new ArrayList()))]);
                    AddSection(new Class("CptS 423",new ArrayList()), new Section(13,1,false)); break;
                case 2:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("CptS 423", new ArrayList()))]);
                    AddSection(new Class("CptS 423", new ArrayList()), new Section(14, 2, false)); break;
                default:
                    throw new Exception();
            }
        }

        // Class 2 combo box changing
        private void class2Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (class2Menu.SelectedIndex)
            {
                case -1:
                case 0:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("PHYS 201", new ArrayList()))]); break;
                case 1:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("PHYS 201", new ArrayList()))]);
                    AddSection(new Class("PHYS 201", new ArrayList()), new Section(13, 1, true)); break;
                case 2:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("PHYS 201", new ArrayList()))]);
                    AddSection(new Class("PHYS 201", new ArrayList()), new Section(14, 2, true)); break;
                case 3:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("PHYS 201", new ArrayList()))]);
                    AddSection(new Class("PHYS 201", new ArrayList()), new Section(12, 3, false)); break;
                default:
                    throw new Exception();
            }
        }

        // Class 3 combo box changing
        private void class3Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (class3Menu.SelectedIndex)
            {
                case -1:
                case 0:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 172", new ArrayList()))]); break;
                case 1:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 172", new ArrayList()))]);
                    AddSection(new Class("MATH 172", new ArrayList()), new Section(9, 1, true)); break;
                case 2:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 172", new ArrayList()))]);
                    AddSection(new Class("MATH 172", new ArrayList()), new Section(13, 2, true)); break;
                case 3:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 172", new ArrayList()))]);
                    AddSection(new Class("MATH 172", new ArrayList()), new Section(10, 3, false)); break;
                default:
                    throw new Exception();
            }
        }

        // Class 4 combo box changing
        private void class4Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (class4Menu.SelectedIndex)
            {
                case -1:
                case 0:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 216", new ArrayList()))]); break;
                case 1:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 216", new ArrayList()))]);
                    AddSection(new Class("MATH 216", new ArrayList()), new Section(9, 1, true)); break;
                case 2:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 216", new ArrayList()))]);
                    AddSection(new Class("MATH 216", new ArrayList()), new Section(14, 2, true)); break;
                case 3:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("MATH 216", new ArrayList()))]);
                    AddSection(new Class("MATH 216", new ArrayList()), new Section(8, 3, true)); break;
                default:
                    throw new Exception();
            }
        }

        // Class 5 combo box changing
        private void class5Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (class5Menu.SelectedIndex)
            {
                case -1:
                case 0:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("CptS 260", new ArrayList()))]); break;
                case 1:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("CptS 260", new ArrayList()))]);
                    AddSection(new Class("CptS 260", new ArrayList()), new Section(10, 1, true)); break;
                case 2:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("CptS 260", new ArrayList()))]);
                    AddSection(new Class("CptS 260", new ArrayList()), new Section(12, 2, true)); break;
                case 3:
                    RemoveClass((Class)listOfClasses[listOfClasses.LastIndexOf(new Class("CptS 260", new ArrayList()))]);
                    AddSection(new Class("CptS 260", new ArrayList()), new Section(11, 3, false)); break;
                default:
                    throw new Exception();
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
