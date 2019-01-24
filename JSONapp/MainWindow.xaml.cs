namespace JSONapp
{
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Appview();
        }


    }
}
