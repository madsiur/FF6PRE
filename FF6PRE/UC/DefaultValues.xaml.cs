using System;
using System.Collections.Generic;
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
    /// Interaction logic for DefaultValues.xaml
    /// </summary>
    public partial class DefaultValues : UserControl
    {
        public DefaultValues()
        {
            InitializeComponent();
        }

        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value1
        {
            get { return (String)GetValue(Value1Property); }
            set { SetValue(Value1Property, value); }
        }

        public static readonly DependencyProperty Value1Property =
            DependencyProperty.Register(nameof(Value1), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value2
        {
            get { return (String)GetValue(Value2Property); }
            set { SetValue(Value2Property, value); }
        }

        public static readonly DependencyProperty Value2Property =
            DependencyProperty.Register(nameof(Value2), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value3
        {
            get { return (String)GetValue(Value3Property); }
            set { SetValue(Value3Property, value); }
        }

        public static readonly DependencyProperty Value3Property =
            DependencyProperty.Register(nameof(Value3), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value4
        {
            get { return (String)GetValue(Value4Property); }
            set { SetValue(Value4Property, value); }
        }

        public static readonly DependencyProperty Value4Property =
            DependencyProperty.Register(nameof(Value4), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value5
        {
            get { return (String)GetValue(Value5Property); }
            set { SetValue(Value5Property, value); }
        }

        public static readonly DependencyProperty Value5Property =
            DependencyProperty.Register(nameof(Value5), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value6
        {
            get { return (String)GetValue(Value6Property); }
            set { SetValue(Value6Property, value); }
        }

        public static readonly DependencyProperty Value6Property =
            DependencyProperty.Register(nameof(Value6), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value7
        {
            get { return (String)GetValue(Value7Property); }
            set { SetValue(Value7Property, value); }
        }

        public static readonly DependencyProperty Value7Property =
            DependencyProperty.Register(nameof(Value7), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public String Value8
        {
            get { return (String)GetValue(Value8Property); }
            set { SetValue(Value8Property, value); }
        }

        public static readonly DependencyProperty Value8Property =
            DependencyProperty.Register(nameof(Value8), typeof(String), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue1
        {
            get { return (bool)GetValue(IsEnabledValue1Property); }
            set { SetValue(IsEnabledValue1Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue1Property =
            DependencyProperty.Register(nameof(IsEnabledValue1), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue2
        {
            get { return (bool)GetValue(IsEnabledValue2Property); }
            set { SetValue(IsEnabledValue2Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue2Property =
            DependencyProperty.Register(nameof(IsEnabledValue2), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue3
        {
            get { return (bool)GetValue(IsEnabledValue3Property); }
            set { SetValue(IsEnabledValue3Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue3Property =
            DependencyProperty.Register(nameof(IsEnabledValue3), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue4
        {
            get { return (bool)GetValue(IsEnabledValue4Property); }
            set { SetValue(IsEnabledValue4Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue4Property =
            DependencyProperty.Register(nameof(IsEnabledValue4), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue5
        {
            get { return (bool)GetValue(IsEnabledValue5Property); }
            set { SetValue(IsEnabledValue5Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue5Property =
            DependencyProperty.Register(nameof(IsEnabledValue5), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue6
        {
            get { return (bool)GetValue(IsEnabledValue6Property); }
            set { SetValue(IsEnabledValue6Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue6Property =
            DependencyProperty.Register(nameof(IsEnabledValue6), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue7
        {
            get { return (bool)GetValue(IsEnabledValue7Property); }
            set { SetValue(IsEnabledValue7Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue7Property =
            DependencyProperty.Register(nameof(IsEnabledValue7), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public bool IsEnabledValue8
        {
            get { return (bool)GetValue(IsEnabledValue8Property); }
            set { SetValue(IsEnabledValue8Property, value); }
        }

        public static readonly DependencyProperty IsEnabledValue8Property =
            DependencyProperty.Register(nameof(IsEnabledValue8), typeof(bool), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand1
        {
            get { return (ICommand)GetValue(ButtonCommand1Property); }
            set { SetValue(ButtonCommand1Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand1Property =
            DependencyProperty.Register(nameof(ButtonCommand1), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand2
        {
            get { return (ICommand)GetValue(ButtonCommand2Property); }
            set { SetValue(ButtonCommand2Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand2Property =
            DependencyProperty.Register(nameof(ButtonCommand2), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand3
        {
            get { return (ICommand)GetValue(ButtonCommand3Property); }
            set { SetValue(ButtonCommand3Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand3Property =
            DependencyProperty.Register(nameof(ButtonCommand3), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand4
        {
            get { return (ICommand)GetValue(ButtonCommand4Property); }
            set { SetValue(ButtonCommand4Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand4Property =
            DependencyProperty.Register(nameof(ButtonCommand4), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand5
        {
            get { return (ICommand)GetValue(ButtonCommand5Property); }
            set { SetValue(ButtonCommand5Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand5Property =
            DependencyProperty.Register(nameof(ButtonCommand5), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand6
        {
            get { return (ICommand)GetValue(ButtonCommand6Property); }
            set { SetValue(ButtonCommand6Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand6Property =
            DependencyProperty.Register(nameof(ButtonCommand6), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand7
        {
            get { return (ICommand)GetValue(ButtonCommand7Property); }
            set { SetValue(ButtonCommand7Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand7Property =
            DependencyProperty.Register(nameof(ButtonCommand7), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ICommand ButtonCommand8
        {
            get { return (ICommand)GetValue(ButtonCommand8Property); }
            set { SetValue(ButtonCommand8Property, value); }
        }

        public static readonly DependencyProperty ButtonCommand8Property =
            DependencyProperty.Register(nameof(ButtonCommand8), typeof(ICommand), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button1Image
        {
            get { return (ImageSource)GetValue(Button1ImageProperty); }
            set { SetValue(Button1ImageProperty, value); }
        }

        public static readonly DependencyProperty Button1ImageProperty =
            DependencyProperty.Register(nameof(Button1Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button2Image
        {
            get { return (ImageSource)GetValue(Button2ImageProperty); }
            set { SetValue(Button2ImageProperty, value); }
        }

        public static readonly DependencyProperty Button2ImageProperty =
            DependencyProperty.Register(nameof(Button2Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button3Image
        {
            get { return (ImageSource)GetValue(Button3ImageProperty); }
            set { SetValue(Button3ImageProperty, value); }
        }

        public static readonly DependencyProperty Button3ImageProperty =
            DependencyProperty.Register(nameof(Button3Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button4Image
        {
            get { return (ImageSource)GetValue(Button4ImageProperty); }
            set { SetValue(Button4ImageProperty, value); }
        }

        public static readonly DependencyProperty Button4ImageProperty =
            DependencyProperty.Register(nameof(Button4Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button5Image
        {
            get { return (ImageSource)GetValue(Button5ImageProperty); }
            set { SetValue(Button5ImageProperty, value); }
        }

        public static readonly DependencyProperty Button5ImageProperty =
            DependencyProperty.Register(nameof(Button5Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button6Image
        {
            get { return (ImageSource)GetValue(Button6ImageProperty); }
            set { SetValue(Button6ImageProperty, value); }
        }

        public static readonly DependencyProperty Button6ImageProperty =
            DependencyProperty.Register(nameof(Button6Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button7Image
        {
            get { return (ImageSource)GetValue(Button7ImageProperty); }
            set { SetValue(Button7ImageProperty, value); }
        }

        public static readonly DependencyProperty Button7ImageProperty =
            DependencyProperty.Register(nameof(Button7Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));

        public ImageSource Button8Image
        {
            get { return (ImageSource)GetValue(Button8ImageProperty); }
            set { SetValue(Button8ImageProperty, value); }
        }

        public static readonly DependencyProperty Button8ImageProperty =
            DependencyProperty.Register(nameof(Button8Image), typeof(ImageSource), typeof(DefaultValues), new FrameworkPropertyMetadata(null));
    }
}
