using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Group : ContentPage
    {
        public Group()
            {
                InitializeComponent();
                // Add some sample data
                var items = new List<GroupedData>();
                items.Add(new GroupedData { Key = "Group 1", Title = "Abilio", Description = "Martinez" });
                items.Add(new GroupedData { Key = "Group 1", Title = "Berlith", Description = "Martinez" });
                items.Add(new GroupedData { Key = "Group 2", Title = "Cristofer", Description = "Martinez" });
                items.Add(new GroupedData { Key = "Group 2", Title = "Diego", Description = "Martinez" });

                // Group the data by the 'Key' property
                var groupedItems = items.GroupBy(i => i.Key)
                                        .Select(g => new Grouping<string, GroupedData>(g.Key, g));

                // Set the ItemsSource property of the ListView to the grouped data
                listView.ItemsSource = groupedItems;
            }
        }

        public class GroupedData
        {
            public string Key { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }

            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Items.Add(item);
            }

        }
}