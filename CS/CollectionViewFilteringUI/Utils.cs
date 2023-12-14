using Microsoft.Maui.Layouts;
using System.ComponentModel;
using System.Globalization;

namespace CollectionViewFilteringUI.Utils {
    public class BoolToColorConverter : IValueConverter {
        public Color FalseSource { get; set; }
        public Color TrueSource { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is bool)) {
                return null;
            }
            return (bool)value ? TrueSource : FalseSource;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class EnumToDescriptionConverter : IMarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return Convert(value);
        }
        public object Convert(object value) {
            var enumValue = (Enum)value;
            var member = enumValue.GetType().GetMember(enumValue.ToString());
            var attributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? ((DescriptionAttribute)attributes[0]).Description : null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }

    public class ScrollViewFix : ScrollView {
        protected override void OnChildAdded(Element child) {
            base.OnChildAdded(child);
            ((VisualElement)child).SizeChanged += OnContentSizeChanged;
        }

        protected override void OnChildRemoved(Element child, int oldLogicalIndex) {
            base.OnChildRemoved(child, oldLogicalIndex);
            ((VisualElement)child).SizeChanged -= OnContentSizeChanged;
        }

        void OnContentSizeChanged(object sender, EventArgs e) {
            InvalidateMeasure();
        }
    }
}
