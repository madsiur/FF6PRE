using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FF6PRE.UC"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FF6PRE.UC;assembly=FF6PRE.UC"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:FilteredComboBox/>
    ///
    /// </summary>
    public class FilteredComboBox : ComboBox
    {
        /*static FilteredComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilteredComboBox), new FrameworkPropertyMetadata(typeof(FilteredComboBox)));
        }*/

        ////

        // Public Fields

        ////



        /// <summary>

        /// The search string treshold length.

        /// </summary>

        /// <remarks>

        /// It's implemented as a Dependency Property, so you can set it in a XAML template 

        /// </remarks>

        public static readonly DependencyProperty MinimumSearchLengthProperty =

            DependencyProperty.Register(

                "MinimumSearchLength",

                typeof(int),

                typeof(FilteredComboBox),

                new UIPropertyMetadata(3));



        ////

        // Private Fields

        //// 



        /// <summary>

        /// Caches the previous value of the filter.

        /// </summary>

        private string oldFilter = string.Empty;



        /// <summary>

        /// Holds the current value of the filter.

        /// </summary>

        private string currentFilter = string.Empty;



        ////

        // Constructors

        //// 



        /// <summary>

        /// Initializes a new instance of the FilteredComboBox class.

        /// </summary>

        /// <remarks>

        /// You could set 'IsTextSearchEnabled' to 'false' here,

        /// to avoid non-intuitive behavior of the control

        /// </remarks>

        public FilteredComboBox()

        {
            this.IsTextSearchEnabled = false;
            this.IsEditable = false;
            this.IsEnabledChanged += OnEnabledChanged;
        }

        private void OnEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if((bool)e.OldValue == true)
            {
                this.Text = string.Empty;
                this.IsDropDownOpen = false;
                this.IsEditable = false;
                this.ClearFilter();
            }
        }



        ////

        // Properties

        //// 



        /// <summary>

        /// Gets or sets the search string treshold length.

        /// </summary>

        /// <value>The minimum length of the search string that triggers filtering.</value>

        [Description("Length of the search string that triggers filtering.")]

        [Category("Filtered ComboBox")]

        [DefaultValue(3)]

        public int MinimumSearchLength

        {

            [System.Diagnostics.DebuggerStepThrough]

            get

            {

                return (int)this.GetValue(MinimumSearchLengthProperty);

            }



            [System.Diagnostics.DebuggerStepThrough]

            set

            {

                this.SetValue(MinimumSearchLengthProperty, value);

            }

        }



        /// <summary>

        /// Gets a reference to the internal editable textbox.

        /// </summary>

        /// <value>A reference to the internal editable textbox.</value>

        /// <remarks>

        /// We need this to get access to the Selection.

        /// </remarks>

        protected TextBox EditableTextBox

        {

            get

            {

                return this.GetTemplateChild("PART_EditableTextBox") as TextBox;

            }

        }



        ////

        // Event Raiser Overrides

        //// 



        /// <summary>

        /// Keep the filter if the ItemsSource is explicitly changed.

        /// </summary>

        /// <param name="oldValue">The previous value of the filter.</param>

        /// <param name="newValue">The current value of the filter.</param>

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)

        {

            if (newValue != null)

            {

                ICollectionView view = CollectionViewSource.GetDefaultView(newValue);

                view.Filter += this.FilterPredicate;

            }



            if (oldValue != null)

            {

                ICollectionView view = CollectionViewSource.GetDefaultView(oldValue);

                view.Filter -= this.FilterPredicate;

            }



            base.OnItemsSourceChanged(oldValue, newValue);

        }



        /// <summary>

        /// Confirm or cancel the selection when Tab, Enter, or Escape are hit. 

        /// Open the DropDown when the Down Arrow is hit.

        /// </summary>

        /// <param name="e">Key Event Args.</param>

        /// <remarks>

        /// The 'KeyDown' event is not raised for Arrows, Tab and Enter keys.

        /// It is swallowed by the DropDown if it's open.

        /// So use the Preview instead.

        /// </remarks>

        protected override void OnPreviewKeyDown(KeyEventArgs e)

        {
            if(e.Key == Key.F1)
            {
                this.IsDropDownOpen = false;
                this.IsEditable = false;
                this.ClearFilter();
            }
            else if (e.Key == Key.F2)
            {
                this.ClearFilter();
                this.Text = string.Empty;
                this.IsEditable = true;
                this.IsDropDownOpen = false;
            }
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                // Explicit Selection -> Close ItemsPanel
                this.IsDropDownOpen = false;
            }

            else if (e.Key == Key.Escape)
            {
                // Escape -> Close DropDown and redisplay Filter
                this.IsDropDownOpen = false;
                this.SelectedIndex = -1;
                this.Text = this.currentFilter;
            }
            else
            {
                if (e.Key == Key.Down)
                {
                    if (this.IsEditable)
                    {
                        // Arrow Down -> Open DropDown
                        this.IsDropDownOpen = true;
                    }
                }

                base.OnPreviewKeyDown(e);
            }

            // Cache text
            this.oldFilter = this.Text;
        }



        /// <summary>

        /// Modify and apply the filter.

        /// </summary>

        /// <param name="e">Key Event Args.</param>

        /// <remarks>

        /// Alternatively, you could react on 'OnTextChanged', but navigating through 

        /// the DropDown will also change the text.

        /// </remarks>

        protected override void OnKeyUp(KeyEventArgs e)

        {

            if (e.Key == Key.Up || e.Key == Key.Down)

            {

                // Navigation keys are ignored

            }

            else if (e.Key == Key.Tab || e.Key == Key.Enter)

            {

                // Explicit Select -> Clear Filter

                this.ClearFilter();

            }

            else

            {

                // The text was changed

                if (this.Text != this.oldFilter)

                {

                    // Clear the filter if the text is empty,

                    // apply the filter if the text is long enough

                    if (this.Text.Length == 0 || this.Text.Length >= this.MinimumSearchLength)

                    {
                        // Update Filter Value

                        this.currentFilter = this.Text;

                        this.RefreshFilter();

                        this.IsDropDownOpen = true;

                        this.Text = this.currentFilter;

                        // Unselect

                        this.EditableTextBox.SelectionStart = int.MaxValue;

                    }

                }



                base.OnKeyUp(e);



            }

        }



        /// <summary>

        /// Make sure the text corresponds to the selection when leaving the control.

        /// </summary>

        /// <param name="e">A KeyBoardFocusChangedEventArgs.</param>

        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)

        {

            this.ClearFilter();

            //int temp = this.SelectedIndex;

            //this.SelectedIndex = -1;

            //this.Text = string.Empty;

            //this.SelectedIndex = temp;

            base.OnPreviewLostKeyboardFocus(e);

        }




        ////

        // Helpers

        ////



        /// <summary>

        /// Re-apply the Filter.

        /// </summary>

        private void RefreshFilter()

        {

            if (this.ItemsSource != null)

            {

                ICollectionView view = CollectionViewSource.GetDefaultView(this.ItemsSource);

                view.Refresh();

            }

        }



        /// <summary>

        /// Clear the Filter.

        /// </summary>

        private void ClearFilter()

        {

            this.currentFilter = string.Empty;

            this.RefreshFilter();

        }



        /// <summary>

        /// The Filter predicate that will be applied to each row in the ItemsSource.

        /// </summary>

        /// <param name="value">A row in the ItemsSource.</param>

        /// <returns>Whether or not the item will appear in the DropDown.</returns>

        private bool FilterPredicate(object value)

        {

            // No filter, no text

            if (value == null)

            {

                return false;

            }



            // No text, no filter

            if (this.Text.Length == 0)

            {

                return true;

            }


            if (this.IsEditable)
            {
                // Case insensitive search
                return value.ToString().ToLower().Contains(this.Text.ToLower());
            }
            else
            {
                return true;
            }

        }
    }
}
