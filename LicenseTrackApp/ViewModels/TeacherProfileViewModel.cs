using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.ViewModels
{
    public class TeacherProfileViewModel : ViewModelBase
    {

        private IServiceProvider serviceProvider;
        private LicenseTrackWebAPIProxy proxy;
        public TeacherProfileViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            TeacherModels teacherModels = (TeacherModels)((App)Application.Current).LoggedInUser;
            UpdateTeacherCommand = new Command(OnUpdateStudent);
            UploadPhotoCommand = new Command(OnUploadPhoto);
            PhotoURL = teacherModels.ProfileImageUrl;
            LocalPhotoPath = "";
            IsPassword = true;
            NameError = "Name is required";
            LastNameError = "Last name is required";
            EmailError = "Email is required";
            PasswordError = "Password must be at least 4 characters long and contain letters and numbers";
            //IdError = "id is required";
            //CityError = "city is required";
            this.Name = teacherModels.FirstName;
            this.LastName = teacherModels.LastName;
            this.Email = teacherModels.Email;
            //this.City = teacherModels.City;
            this.Password = teacherModels.PasswordHash;
            this.SchoolName = teacherModels.SchoolName;
            this.ManualCar = teacherModels.ManualCar;   
            this.VehicleType = teacherModels.VehicleType;
            this.TeachingArea = teacherModels.TeachingArea;
            this.ConfirmationStatus = teacherModels.ConfirmationStatus;

        }

        //Defiine properties for each field in the registration form including error messages and validation logic

        private string schoolName;
        public string SchoolName
        {
            get => schoolName;
            set
            {
                schoolName = value;
                OnPropertyChanged("SchoolName");
            }
        }

        private bool? manualCar;
        public bool? ManualCar
        {
            get => manualCar;
            set
            {
                manualCar = value;
                OnPropertyChanged("ManualCar");
            }
        }

        private string vehicleType;
        public string VehicleType
        {
            get => vehicleType;
            set
            {
                vehicleType = value;
                OnPropertyChanged("VehicleType");
            }
        }

        private string teachingArea;
        public string TeachingArea
        {
            get => teachingArea;
            set
            {
                teachingArea = value;
                OnPropertyChanged("TeachingArea");
            }
        }

        private int? confirmationStatus;
        public int? ConfirmationStatus
        {
            get => confirmationStatus;
            set
            {
                confirmationStatus = value;
                OnPropertyChanged("ConfirmationStatus");
            }
        }


        #region Name
        private bool showNameError;

        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName();
                OnPropertyChanged("Name");
            }
        }

        private string nameError;

        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }
        #endregion

        #region LastName
        private bool showLastNameError;

        public bool ShowLastNameError
        {
            get => showLastNameError;
            set
            {
                showLastNameError = value;
                OnPropertyChanged("ShowLastNameError");
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                ValidateLastName();
                OnPropertyChanged("LastName");
            }
        }

        private string lastNameError;

        public string LastNameError
        {
            get => lastNameError;
            set
            {
                lastNameError = value;
                OnPropertyChanged("LastNameError");
            }
        }

        private void ValidateLastName()
        {
            this.ShowLastNameError = string.IsNullOrEmpty(LastName);
        }
        #endregion
        #region Email
        private bool showEmailError;

        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                ValidateEmail();
                OnPropertyChanged("Email");
            }
        }

        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private void ValidateEmail()
        {
            this.ShowEmailError = string.IsNullOrEmpty(Email);
            if (!ShowEmailError)
            {
                //check if email is in the correct format using regular expression
                if (!System.Text.RegularExpressions.Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    EmailError = "Email is not valid";
                    ShowEmailError = true;
                }
                else
                {
                    EmailError = "";
                    ShowEmailError = false;
                }
            }
            else
            {
                EmailError = "Email is required";
            }
        }
        #endregion
        #region Password
        private bool showPasswordError;

        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                ValidatePassword();
                OnPropertyChanged("Password");
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private void ValidatePassword()
        {
            //Password must include characters and numbers and be longer than 4 characters
            if (string.IsNullOrEmpty(password) ||
                password.Length < 4 ||
                !password.Any(char.IsDigit) ||
                !password.Any(char.IsLetter))
            {
                this.ShowPasswordError = true;
            }
            else
                this.ShowPasswordError = false;
        }

        //This property will indicate if the password entry is a password
        private bool isPassword = true;
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                isPassword = value;
                OnPropertyChanged("IsPassword");
            }
        }


        #endregion


        //#region City
        //private bool showCityError;

        //public bool ShowCityError
        //{
        //    get => showCityError;
        //    set
        //    {
        //        showCityError = value;
        //        OnPropertyChanged("ShowCityError");
        //    }
        //}

        //private string city;

        //public string City
        //{
        //    get => city;
        //    set
        //    {
        //        city = value;
        //        ValidateCity();
        //        OnPropertyChanged("City");
        //    }
        //}

        //private string cityError;

        //public string CityError
        //{
        //    get => cityError;
        //    set
        //    {
        //        cityError = value;
        //        OnPropertyChanged("CityError");
        //    }
        //}

        //private void ValidateCity()
        //{
        //    this.ShowCityError = string.IsNullOrEmpty(City);
        //}
        //#endregion

        #region Photo

        private string photoURL;

        public string PhotoURL
        {
            get => photoURL;
            set
            {
                photoURL = value;
                OnPropertyChanged("PhotoURL");
            }
        }

        private string localPhotoPath;

        public string LocalPhotoPath
        {
            get => localPhotoPath;
            set
            {
                localPhotoPath = value;
                OnPropertyChanged("LocalPhotoPath");
            }
        }

        public Command UploadPhotoCommand { get; }
        //This method open the file picker to select a photo
        private async void OnUploadPhoto()
        {
            try
            {
                var result = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Please select a photo",
                });

                if (result != null)
                {
                    // The user picked a file
                    this.LocalPhotoPath = result.FullPath;
                    this.PhotoURL = result.FullPath;
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void UpdatePhotoURL(string virtualPath)
        {
            Random r = new Random();
            PhotoURL = proxy.GetImagesBaseAddress() + virtualPath + "?v=" + r.Next();
            LocalPhotoPath = "";
        }

        #endregion

        //Define a command for the register button
        public Command UpdateTeacherCommand { get; }

        //Define a method that will be called when the register button is clicked
        public async void OnUpdateStudent()
        {
            ValidateName();
            ValidateLastName();
            ValidateEmail();
            ValidatePassword();
            //ValidateCity();
            if (!ShowNameError && !ShowLastNameError && !ShowEmailError && !ShowPasswordError)
            {
                TeacherModels theTeacher = (TeacherModels)((App)Application.Current).LoggedInUser;
                theTeacher.FirstName = Name;
                theTeacher.LastName = LastName;
                theTeacher.Email = Email;
                theTeacher.PasswordHash = Password;
                theTeacher.IsManager = false;
                //theTeacher.City = City;
                theTeacher.SchoolName = SchoolName;
                theTeacher.ManualCar = ManualCar;
                theTeacher.VehicleType = VehicleType;
                theTeacher.TeachingArea = TeachingArea;
                theTeacher.ConfirmationStatus = ConfirmationStatus;
                theTeacher.FileExtension = GetImageExtention();


                //Call the Register method on the proxy to register the new user
                InServerCall = true;
                theTeacher = await proxy.UpdateTeacher(theTeacher);
                InServerCall = false;

                //If the registration was successful, navigate to the login page
                if (theTeacher != null)
                {
                    //UPload profile imae if needed
                    if (!string.IsNullOrEmpty(LocalPhotoPath))
                    {
                        UsersModels? updatedUser = await proxy.UploadProfileImage(LocalPhotoPath);
                        if (updatedUser == null)
                        {
                            InServerCall = false;
                            await Application.Current.MainPage.DisplayAlert("Update profile", "User Data Was Saved BUT Profile image upload failed", "ok");
                        }
                    }
                    InServerCall = false;
                    await Shell.Current.DisplayAlert("Save Profile", "Profile saved successfully", "ok");

                }
                else
                {

                    //If the registration failed, display an error message
                    string errorMsg = "update profile failed. Please try again.";
                    await Application.Current.MainPage.DisplayAlert("Update profile", errorMsg, "ok");
                }
            }
        }

        private string GetImageExtention()
        {
            int index = this.LocalPhotoPath.LastIndexOf(".");
            if (index == -1)
                return "";
            return this.LocalPhotoPath.Substring(index);
        }


    }
}
