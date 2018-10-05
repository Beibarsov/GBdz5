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
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WpfGB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Работники
        List<Employee> employees = new List<Employee>();
        //Отделы
        List<Department> departments = new List<Department>();
        //Связующий служебный класс, содержащий iD работника и ID отдела в связке, что обеспечивает их непосредственную связь
        List<WhoIsDepartament> whoIsDepartaments = new List<WhoIsDepartament>();
        public MainWindow()
        {
            InitializeComponent();

            employees.Add(new Employee(20, "Василий Петрович"));
            employees.Add(new Employee(24, "Василий Федорович"));

            departments.Add(new Department("Финансовый отдел"));
            departments.Add(new Department("Технический отдел"));

            whoIsDepartaments.Add(new WhoIsDepartament(1));
            whoIsDepartaments.Add(new WhoIsDepartament(2));
            UpdateElement();

            //Employee.ToolTip = employees.Find(v => v.Name == "Василий Петрович").Name.ToString();
            MessageBox.Show("Для выбора сотрудника выберете его из первого списка. После будет доступно редактирование");
            Editor.IsEnabled = false;







        }
        /// <summary>
        /// При изменении списка работников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeEmp(object sender, RoutedEventArgs e)
        {
            var Text = from emplo in employees
                       where (emplo == Employee.SelectedItem)
                       join wid in whoIsDepartaments
                       on emplo.ID equals wid.IDempl
                       join depar in departments
                       on wid.IDdepr equals depar.ID
                       select new { Name = emplo.Name, Age = emplo.Age, Dep = depar.NameDepartament };
            foreach (var item in Text)
            {
                TextBox1.Text = ($"{item.Name} {item.Age} лет, отдел {item.Dep} ");
            }
            var sel = from emplo in employees
                      where (emplo == Employee.SelectedItem)
                      join wid in whoIsDepartaments
                      on emplo.ID equals wid.IDempl
                      join depar in departments
                      on wid.IDdepr equals depar.ID
                      select depar;
            foreach (var item in sel)
            {
                Department.SelectedItem = item;
            }
            Editor.IsEnabled = true;
            TextAge.Text = employees[Employee.SelectedIndex].Age.ToString();
            TextName.Text = employees[Employee.SelectedIndex].Name.ToString();


        }
        /// <summary>
        /// Событие нажатия на кнопку "Редактировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditEmp(object sender, RoutedEventArgs e)
        {
            if (IsCorrect())
            {
                MessageBox.Show("Теперь у работника другие данные");
                var el = from emplo in employees
                         where emplo == employees[Employee.SelectedIndex]
                         join wid in whoIsDepartaments
                         on emplo.ID equals wid.IDempl
                         select wid;
                foreach (var item in el)
                {
                    item.IDdepr = Department.SelectedIndex;
                }
                employees[Employee.SelectedIndex].Age = int.Parse(TextAge.Text);
                employees[Employee.SelectedIndex].Name = TextName.Text;
                UpdateElement();
            }
        }




        /// <summary>
        /// Событие нажатия на кнопку "Новое"
        /// </summary>
        private void NewEmp(object sender, RoutedEventArgs e)
        {
            if (IsCorrect())
            {
                employees.Add(new Employee(int.Parse(TextAge.Text), TextName.Text));
                whoIsDepartaments.Add(new WhoIsDepartament(Department.SelectedIndex));
                UpdateElement();
                MessageBox.Show("работник создан");
            }
        }


        /// <summary>
        /// Перерисовка дин. элементов (надписей и т.д.)
        /// </summary>
        private void UpdateElement()
        {
            Employee.ItemsSource = employees;
            Employee.UpdateLayout();
            Department.ItemsSource = departments;
        }
        private bool IsCorrect()
        {
            string regex = @"^[0-9]+$";
            if (!Regex.IsMatch(TextAge.Text, regex))
            {
                MessageBox.Show("Возраст нужно вводить числами");
                return false;
            }
            return true;
        }


    }
}
