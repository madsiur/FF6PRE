using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FF6PRE.UC
{
    /// <summary>
    /// Interaction logic for ActValues.xaml
    /// </summary>
    public partial class ActValues : UserControl
    {
        public ActValues()
        {
            InitializeComponent();
        }

        public List<string> Descriptions1
        {
            get { return (List<string>)GetValue(Descriptions1Property); }
            set { SetValue(Descriptions1Property, value); }
        }

        public static readonly DependencyProperty Descriptions1Property =
            DependencyProperty.Register(nameof(Descriptions1), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public List<string> Descriptions2
        {
            get { return (List<string>)GetValue(Descriptions2Property); }
            set { SetValue(Descriptions2Property, value); }
        }

        public static readonly DependencyProperty Descriptions2Property =
            DependencyProperty.Register(nameof(Descriptions2), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public List<string> Descriptions3
        {
            get { return (List<string>)GetValue(Descriptions3Property); }
            set { SetValue(Descriptions3Property, value); }
        }

        public static readonly DependencyProperty Descriptions3Property =
            DependencyProperty.Register(nameof(Descriptions3), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public List<string> Descriptions4
        {
            get { return (List<string>)GetValue(Descriptions4Property); }
            set { SetValue(Descriptions4Property, value); }
        }

        public static readonly DependencyProperty Descriptions4Property =
            DependencyProperty.Register(nameof(Descriptions4), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public List<string> Descriptions5
        {
            get { return (List<string>)GetValue(Descriptions5Property); }
            set { SetValue(Descriptions5Property, value); }
        }

        public static readonly DependencyProperty Descriptions5Property =
            DependencyProperty.Register(nameof(Descriptions5), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public List<string> Descriptions6
        {
            get { return (List<string>)GetValue(Descriptions6Property); }
            set { SetValue(Descriptions6Property, value); }
        }

        public static readonly DependencyProperty Descriptions6Property =
            DependencyProperty.Register(nameof(Descriptions6), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public List<string> Descriptions7
        {
            get { return (List<string>)GetValue(Descriptions7Property); }
            set { SetValue(Descriptions7Property, value); }
        }

        public static readonly DependencyProperty Descriptions7Property =
            DependencyProperty.Register(nameof(Descriptions7), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public List<string> Descriptions8
        {
            get { return (List<string>)GetValue(Descriptions8Property); }
            set { SetValue(Descriptions8Property, value); }
        }

        public static readonly DependencyProperty Descriptions8Property =
            DependencyProperty.Register(nameof(Descriptions8), typeof(List<string>), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value1
        {
            get { return (String)GetValue(Value1Property); }
            set { SetValue(Value1Property, value); }
        }

        public static readonly DependencyProperty Value1Property =
            DependencyProperty.Register(nameof(Value1), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value2
        {
            get { return (String)GetValue(Value2Property); }
            set { SetValue(Value2Property, value); }
        }

        public static readonly DependencyProperty Value2Property =
            DependencyProperty.Register(nameof(Value2), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value3
        {
            get { return (String)GetValue(Value3Property); }
            set { SetValue(Value3Property, value); }
        }

        public static readonly DependencyProperty Value3Property =
            DependencyProperty.Register(nameof(Value3), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value4
        {
            get { return (String)GetValue(Value4Property); }
            set { SetValue(Value4Property, value); }
        }

        public static readonly DependencyProperty Value4Property =
            DependencyProperty.Register(nameof(Value4), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value5
        {
            get { return (String)GetValue(Value5Property); }
            set { SetValue(Value5Property, value); }
        }

        public static readonly DependencyProperty Value5Property =
            DependencyProperty.Register(nameof(Value5), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value6
        {
            get { return (String)GetValue(Value6Property); }
            set { SetValue(Value6Property, value); }
        }

        public static readonly DependencyProperty Value6Property =
            DependencyProperty.Register(nameof(Value6), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value7
        {
            get { return (String)GetValue(Value7Property); }
            set { SetValue(Value7Property, value); }
        }

        public static readonly DependencyProperty Value7Property =
            DependencyProperty.Register(nameof(Value7), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String Value8
        {
            get { return (String)GetValue(Value8Property); }
            set { SetValue(Value8Property, value); }
        }

        public static readonly DependencyProperty Value8Property =
            DependencyProperty.Register(nameof(Value8), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription1
        {
            get { return (String)GetValue(SelectedDescription1Property); }
            set { SetValue(SelectedDescription1Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription1Property =
            DependencyProperty.Register(nameof(SelectedDescription1), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription2
        {
            get { return (String)GetValue(SelectedDescription2Property); }
            set { SetValue(SelectedDescription2Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription2Property =
            DependencyProperty.Register(nameof(SelectedDescription2), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription3
        {
            get { return (String)GetValue(SelectedDescription3Property); }
            set { SetValue(SelectedDescription3Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription3Property =
            DependencyProperty.Register(nameof(SelectedDescription3), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription4
        {
            get { return (String)GetValue(SelectedDescription4Property); }
            set { SetValue(SelectedDescription4Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription4Property =
            DependencyProperty.Register(nameof(SelectedDescription4), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription5
        {
            get { return (String)GetValue(SelectedDescription5Property); }
            set { SetValue(SelectedDescription5Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription5Property =
            DependencyProperty.Register(nameof(SelectedDescription5), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription6
        {
            get { return (String)GetValue(SelectedDescription6Property); }
            set { SetValue(SelectedDescription6Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription6Property =
            DependencyProperty.Register(nameof(SelectedDescription6), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription7
        {
            get { return (String)GetValue(SelectedDescription7Property); }
            set { SetValue(SelectedDescription7Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription7Property =
            DependencyProperty.Register(nameof(SelectedDescription7), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public String SelectedDescription8
        {
            get { return (String)GetValue(SelectedDescription8Property); }
            set { SetValue(SelectedDescription8Property, value); }
        }

        public static readonly DependencyProperty SelectedDescription8Property =
            DependencyProperty.Register(nameof(SelectedDescription8), typeof(String), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue1
        {
            get { return (bool)GetValue(IsEnabledValue1Property); }
            set { SetValue(IsEnabledValue1Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue1Property =
            DependencyProperty.Register(nameof(IsEnabledValue1), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue2
        {
            get { return (bool)GetValue(IsEnabledValue2Property); }
            set { SetValue(IsEnabledValue2Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue2Property =
            DependencyProperty.Register(nameof(IsEnabledValue2), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue3
        {
            get { return (bool)GetValue(IsEnabledValue3Property); }
            set { SetValue(IsEnabledValue3Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue3Property =
            DependencyProperty.Register(nameof(IsEnabledValue3), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue4
        {
            get { return (bool)GetValue(IsEnabledValue4Property); }
            set { SetValue(IsEnabledValue4Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue4Property =
            DependencyProperty.Register(nameof(IsEnabledValue4), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue5
        {
            get { return (bool)GetValue(IsEnabledValue5Property); }
            set { SetValue(IsEnabledValue5Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue5Property =
            DependencyProperty.Register(nameof(IsEnabledValue5), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue6
        {
            get { return (bool)GetValue(IsEnabledValue6Property); }
            set { SetValue(IsEnabledValue6Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue6Property =
            DependencyProperty.Register(nameof(IsEnabledValue6), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue7
        {
            get { return (bool)GetValue(IsEnabledValue7Property); }
            set { SetValue(IsEnabledValue7Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue7Property =
            DependencyProperty.Register(nameof(IsEnabledValue7), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue8
        {
            get { return (bool)GetValue(IsEnabledValue8Property); }
            set { SetValue(IsEnabledValue8Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue8Property =
            DependencyProperty.Register(nameof(IsEnabledValue8), typeof(bool), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand1
        {
            get { return (ICommand)GetValue(ButtonCommand1Property); }
            set { SetValue(ButtonCommand1Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand1Property =
            DependencyProperty.Register(nameof(ButtonCommand1), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand2
        {
            get { return (ICommand)GetValue(ButtonCommand2Property); }
            set { SetValue(ButtonCommand2Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand2Property =
            DependencyProperty.Register(nameof(ButtonCommand2), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand3
        {
            get { return (ICommand)GetValue(ButtonCommand3Property); }
            set { SetValue(ButtonCommand3Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand3Property =
            DependencyProperty.Register(nameof(ButtonCommand3), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand4
        {
            get { return (ICommand)GetValue(ButtonCommand4Property); }
            set { SetValue(ButtonCommand4Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand4Property =
            DependencyProperty.Register(nameof(ButtonCommand4), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand5
        {
            get { return (ICommand)GetValue(ButtonCommand5Property); }
            set { SetValue(ButtonCommand5Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand5Property =
            DependencyProperty.Register(nameof(ButtonCommand5), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand6
        {
            get { return (ICommand)GetValue(ButtonCommand6Property); }
            set { SetValue(ButtonCommand6Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand6Property =
            DependencyProperty.Register(nameof(ButtonCommand6), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand7
        {
            get { return (ICommand)GetValue(ButtonCommand7Property); }
            set { SetValue(ButtonCommand7Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand7Property =
            DependencyProperty.Register(nameof(ButtonCommand7), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand8
        {
            get { return (ICommand)GetValue(ButtonCommand8Property); }
            set { SetValue(ButtonCommand8Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand8Property =
            DependencyProperty.Register(nameof(ButtonCommand8), typeof(ICommand), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button1Brush
        {
            get { return (Brush)GetValue(Button1BrushProperty); }
            set { SetValue(Button1BrushProperty, value); }
        }

        public static readonly DependencyProperty Button1BrushProperty =
            DependencyProperty.Register(nameof(Button1Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button2Brush
        {
            get { return (Brush)GetValue(Button2BrushProperty); }
            set { SetValue(Button2BrushProperty, value); }
        }

        public static readonly DependencyProperty Button2BrushProperty =
            DependencyProperty.Register(nameof(Button2Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button3Brush
        {
            get { return (Brush)GetValue(Button3BrushProperty); }
            set { SetValue(Button3BrushProperty, value); }
        }

        public static readonly DependencyProperty Button3BrushProperty =
            DependencyProperty.Register(nameof(Button3Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button4Brush
        {
            get { return (Brush)GetValue(Button4BrushProperty); }
            set { SetValue(Button4BrushProperty, value); }
        }

        public static readonly DependencyProperty Button4BrushProperty =
            DependencyProperty.Register(nameof(Button4Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button5Brush
        {
            get { return (Brush)GetValue(Button5BrushProperty); }
            set { SetValue(Button5BrushProperty, value); }
        }

        public static readonly DependencyProperty Button5BrushProperty =
            DependencyProperty.Register(nameof(Button5Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button6Brush
        {
            get { return (Brush)GetValue(Button6BrushProperty); }
            set { SetValue(Button6BrushProperty, value); }
        }

        public static readonly DependencyProperty Button6BrushProperty =
            DependencyProperty.Register(nameof(Button6Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button7Brush
        {
            get { return (Brush)GetValue(Button7BrushProperty); }
            set { SetValue(Button7BrushProperty, value); }
        }

        public static readonly DependencyProperty Button7BrushProperty =
            DependencyProperty.Register(nameof(Button7Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));

        public Brush Button8Brush
        {
            get { return (Brush)GetValue(Button8BrushProperty); }
            set { SetValue(Button8BrushProperty, value); }
        }

        public static readonly DependencyProperty Button8BrushProperty =
            DependencyProperty.Register(nameof(Button8Brush), typeof(Brush), typeof(ActValues), new FrameworkPropertyMetadata(null));
    }
}
