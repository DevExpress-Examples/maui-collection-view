using BottomSheetFilterUI.Model;
using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BottomSheetFilterUI.ViewModel {
    public class MainViewModel : BindableBase {
        public ObservableCollection<Tutor> Tutors { get; set; }
        public MainViewModel() {
            Tutors = new ObservableCollection<Tutor>() {
                new Tutor() { FirstName = "Albert", LastName="Menendez", Experience = 3, Rating=5f, HourRate=39, Subject="Mathematics", City = "New York", AvatarPath="albertmenendez" },
                new Tutor() { FirstName = "Alcorn", LastName="Mathewson", Experience = 3, Rating=4.5f, HourRate=24, Subject="History", City = "Los Angeles", AvatarPath="alcornmathewson" },
                new Tutor() { FirstName = "Alex", LastName="James", Experience = 3, Rating=4.8f, HourRate=35, Subject="Geometry", City = "Chicago", AvatarPath="alexjames" },
                new Tutor() { FirstName = "Alfred", LastName="Newman", Experience = 3, Rating=4.7f, HourRate=31, Subject="Physics", City = "Houston", AvatarPath="alfrednewman" },
                new Tutor() { FirstName = "Beau", LastName="Alessandro", Experience = 3, Rating=5f, HourRate=38, Subject="Chemistry", City = "Phoenix", AvatarPath="beaualessandro" },
                new Tutor() { FirstName = "Benjamin", LastName="Johonson", Experience = 3, Rating=4.8f, HourRate=33, Subject="Biology", City = "Chicago", AvatarPath="benjaminjohonson" },
                new Tutor() { FirstName = "Bobbie", LastName="Valentine", Experience = 3, Rating=4.6f, HourRate=39, Subject="English", City = "San Diego", AvatarPath="bobbievalentine" },
                new Tutor() { FirstName = "Christa", LastName="Christie", Experience = 3, Rating=4.4f, HourRate=41, Subject="Chemistry", City = "New York", AvatarPath="christachristie" },
                new Tutor() { FirstName = "Frank", LastName="Frankson", Experience = 3, Rating=5f, HourRate=43, Subject="Computer Science", City = "Seattle", AvatarPath="frankfrankson" },
                new Tutor() { FirstName = "Henry", LastName="Mcallister", Experience = 3, Rating=4.6f, HourRate=42, Subject="Economics", City = "Denver", AvatarPath="henrymcallister" },
                new Tutor() { FirstName = "Jennie", LastName="Valintine", Experience = 3, Rating=4.7f, HourRate=30, Subject="Mathematics", City = "Denver", AvatarPath="jennievalintine" },
                new Tutor() { FirstName = "Jimmie", LastName="Jones", Experience = 3, Rating=5f, HourRate=45, Subject="Computer Science", City = "Seattle", AvatarPath="jimmiejones" },
                new Tutor() { FirstName = "John", LastName="Doe", Experience = 3, Rating=4.7f, HourRate=45, Subject="Mathematics", City = "Seattle", AvatarPath="johndoe" },
                new Tutor() { FirstName = "Karen", LastName="Holmes", Experience = 3, Rating=4.5f, HourRate=31, Subject="History", City = "Chicago", AvatarPath="karenholmes" },
                new Tutor() { FirstName = "Leticia", LastName="Ford", Experience = 3, Rating=4.9f, HourRate=49, Subject="Mathematics", City = "New York", AvatarPath="leticiaford" },
                new Tutor() { FirstName = "Michael", LastName="Jeffers", Experience = 3, Rating=4.5f, HourRate=43, Subject="Mathematics", City = "New York", AvatarPath="michaeljeffers" },
                new Tutor() { FirstName = "Mickey", LastName="Alcorn", Experience = 3, Rating=4.3f, HourRate=29, Subject="Geometry", City = "Phoenix", AvatarPath="mickeyalcorn" },
                new Tutor() { FirstName = "Mildred", LastName="Johansson", Experience = 3, Rating=4.5f, HourRate=32, Subject="English", City = "Los Angeles", AvatarPath="mildredjohansson" },
                new Tutor() { FirstName = "Roger", LastName="Michelson", Experience = 3, Rating=5f, HourRate=33, Subject="Mathematics", City = "New York", AvatarPath="rogermichelson" },
                new Tutor() { FirstName = "Sam", LastName="Hill", Experience = 3, Rating=4.4f, HourRate=31, Subject="English", City = "Houston", AvatarPath="samhill" },
            };
        }
    }
}
