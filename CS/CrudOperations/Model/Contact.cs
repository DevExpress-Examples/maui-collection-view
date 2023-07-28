using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Maui.Core;
using Microsoft.Maui.ApplicationModel.Communication;

namespace CrudOperations.Model {
    public class Contact : BindableBase {
        static ImageSource noPhotoImageSource = ImageSource.FromFile("noavatar");

        int? id;
        string firstName;
        string lastName;
        string company;
        string address;
        string city;
        string state;
        string email;
        int zipcode;
        string homephone;
        ImageSource imageSource;

        public int? ID {
            get => id;
            set {
                id = value;
                RaisePropertiesChanged();
            }
        }
        public char FirstNameChar => FirstName[0];
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName {
            get => firstName;
            set {
                firstName = value;
                RaisePropertiesChanged();
            }
        }
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName {
            get => lastName;
            set {
                lastName = value;
                RaisePropertiesChanged();
            }
        }
        public string Company {
            get => company;
            set {
                company = value;
                RaisePropertiesChanged();
            }
        }
        public string Address {
            get => address;
            set {
                address = value;
                RaisePropertiesChanged();
            }
        }
        public string City {
            get => city;
            set {
                city = value;
                RaisePropertiesChanged();
            }
        }
        public string State {
            get => state;
            set {
                state = value;
                RaisePropertiesChanged();
            }
        }
        public int ZipCode {
            get => zipcode;
            set {
                zipcode = value;
                RaisePropertiesChanged();
            }
        }
        public string HomePhone {
            get => homephone;
            set {
                homephone = value;
                RaisePropertiesChanged();
            }
        }
        public string Email {
            get => email;
            set {
                email = value;
                RaisePropertiesChanged();
            }
        }

        [NotMapped]
        //public string PhotoImagePath {
        //    get {
        //        if (!string.IsNullOrEmpty(photoImagePath))
        //            return photoImagePath;
        //        if (id is < 0 or > 20)
        //            return noPhotoImagePath;
        //        return photoImagePath = $"id{id}.png";
        //    }
        //}
        public ImageSource PhotoImageSource {
            get {
                if (imageSource is not null)
                    return imageSource;
                if (this.id is < 0 or > 20)
                    return imageSource = noPhotoImageSource;
                return imageSource = ImageSource.FromFile("id" + this.id + ".png");
            }
        }
    }
}