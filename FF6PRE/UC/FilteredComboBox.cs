using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FF6PRE.UC
{
    public class FilteredComboBox : ComboBox
    {
        private string oldFilter = string.Empty;
        private string currentFilter = string.Empty;
        private bool textBoxMode = false;

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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (this.EditableTextBox != null)
            {
                this.EditableTextBox.Focus();
            }
        }

        protected TextBox EditableTextBox
        {
            get
            {
                return this.GetTemplateChild("PART_EditableTextBox") as TextBox;
            }
        }

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

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if(e.Key == Key.F1)
            {
                if (this.textBoxMode)
                {
                    // set regular mode
                    this.Text = string.Empty;
                    this.ClearFilter();
                    this.IsDropDownOpen = false;
                    this.IsEditable = false;
                    this.textBoxMode = false;
                    this.SelectedItem = ((List<string>)this.ItemsSource)[0];
                    this.Focus();
                }
                else
                {
                    // set editable mode
                    this.ClearFilter();
                    this.Text = string.Empty;
                    this.IsEditable = true;
                    this.IsDropDownOpen = false;
                    this.textBoxMode = true;
                }
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
                    this.currentFilter = this.Text;
                    this.RefreshFilter();
                    this.IsDropDownOpen = true;
                    this.Text = this.currentFilter;
                    this.EditableTextBox.SelectionStart = int.MaxValue;
                }

                base.OnKeyUp(e);
            }
        }

        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            this.ClearFilter();
            base.OnPreviewLostKeyboardFocus(e);
        }

        private void RefreshFilter()
        {
            if (this.ItemsSource != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(this.ItemsSource);
                view.Refresh();
            }
        }

        private void ClearFilter()
        {
            this.currentFilter = string.Empty;
            this.RefreshFilter();
        }

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
