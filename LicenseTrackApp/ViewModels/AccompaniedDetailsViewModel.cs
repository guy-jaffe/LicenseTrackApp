using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.ViewModels
{
    public class AccompaniedDetailsViewModel : ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public AccompaniedDetailsViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider;
            StudentModels studentModels = (StudentModels)((App)Application.Current).LoggedInUser;
            this.earningLicenseDate = studentModels.LicenseAcquisitionDate.Value;
            TimeSpan s1 = earningLicenseDate.ToDateTime(new TimeOnly(0)) - DateTime.Now;
            morningDays = s1.Days+90;
            nightDays = morningDays + 90;
            finishNewDriverDate = earningLicenseDate.AddYears(2);
        }

        private int morningDays;
        public int MorningDays
        {
            get => morningDays;
            set
            {
                if (morningDays != value)
                {
                    morningDays = value;
                    OnPropertyChanged(nameof(MorningDays));
                }
            }
        }

        private int nightDays;
        public int NightDays
        {
            get => nightDays;
            set
            {
                if (nightDays != value)
                {
                    nightDays = value;
                    OnPropertyChanged(nameof(NightDays));
                }
            }
        }

        private DateOnly earningLicenseDate;
        public DateOnly EarningLicenseDate
        {
            get => earningLicenseDate;
            set
            {
                if (earningLicenseDate != value)
                {
                    earningLicenseDate = value;
                    OnPropertyChanged(nameof(EarningLicenseDate));
                }
            }
        }

        private DateOnly finishNewDriverDate;
        public DateOnly FinishNewDriverDate
        {
            get => finishNewDriverDate;
            set
            {
                if (finishNewDriverDate != value)
                {
                    finishNewDriverDate = value;
                    OnPropertyChanged(nameof(FinishNewDriverDate));
                }
            }
        }

    }
}
