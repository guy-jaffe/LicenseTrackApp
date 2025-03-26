using LicenseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using LicenseTrackApp.Models;

namespace LicenseTrackApp.Services
{
    public class LicenseTrackWebAPIProxy
    {
        #region without tunnel
        /*
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "localhost";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110/api/" : $"http://{serverIP}:5110/api/";
        private static string ImageBaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110" : $"http://{serverIP}:5110";
        */
        #endregion

        #region with tunnel
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "xxgd7p2z-5070.euw.devtunnels.ms";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = "https://xxgd7p2z-5070.euw.devtunnels.ms/api/";
        public static string ImageBaseAddress = "https://xxgd7p2z-5070.euw.devtunnels.ms/";
        #endregion

        public LicenseTrackWebAPIProxy()
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            this.client = new HttpClient(handler);
            this.baseUrl = BaseAddress;
        }

        public string GetImagesBaseAddress()
        {
            return LicenseTrackWebAPIProxy.ImageBaseAddress;
        }

        public string GetDefaultProfilePhotoUrl()
        {
            return $"{LicenseTrackWebAPIProxy.ImageBaseAddress}/profileImages/default.png";
        }

        public async Task<UsersModels?> LoginAsync(LoginInfoModels userInfo)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}login";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(userInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    UsersModels? result = null;
                    StudentModels? student = JsonSerializer.Deserialize<StudentModels>(resContent, options);
                    TeacherModels? teacher = JsonSerializer.Deserialize<TeacherModels>(resContent, options);
                    if (student.LicenseStatus == null)
                    {
                        if (teacher.ManualCar != null)
                        {
                            result = teacher;
                        }
                        else
                            result = JsonSerializer.Deserialize<UsersModels>(resContent, options);
                    }
                    else
                        result = student;
                
                
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //This methos call the Register web API on the server and return the AppUser object with the given ID
        //or null if the call fails
        public async Task<StudentModels?> StudentRegister(StudentModels user)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}studentRegister";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    StudentModels? result = JsonSerializer.Deserialize<StudentModels>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<StudentModels?> UpdateStudent(StudentModels user)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}updateStudend";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    StudentModels? result = JsonSerializer.Deserialize<StudentModels>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> UpdateLesson(LessonModels lesson)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}updateLesson";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(lesson);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<TeacherModels?> UpdateTeacher(TeacherModels user)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}updateTeacher";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    TeacherModels? result = JsonSerializer.Deserialize<TeacherModels>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<TeacherModels?> TeacherRegister(TeacherModels user)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}teacherRegister";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    TeacherModels? result = JsonSerializer.Deserialize<TeacherModels>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UsersModels?> UploadProfileImage(string imagePath)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}uploadprofileimage";
            try
            {
                //Create the form data
                MultipartFormDataContent form = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes(imagePath));
                form.Add(fileContent, "file", imagePath);
                //Call the server API
                HttpResponseMessage response = await client.PostAsync(url, form);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    UsersModels? result = JsonSerializer.Deserialize<UsersModels>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<LessonScheduleModels>?> GetAvailableLessonSchedules(int teacherId, int month, int year)
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}getAvailableLessonSchedules?teacherId={teacherId}&month={month}&year={year}";

            try
            {
                
                // קריאה ל-API
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התשובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת LessonSchedule
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<LessonScheduleModels>? result = JsonSerializer.Deserialize<List<LessonScheduleModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> AddLesson(LessonModels lesson)
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}addLesson";

            try
            {
                // המרת הנתונים ל-JSON
                string json = JsonSerializer.Serialize(lesson);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // שליחת הבקשה לשרת
                HttpResponseMessage response = await client.PostAsync(url, content);

                // אם התגובה תקינה (סטטוס 200-299), מחזירים true
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<List<TeacherModels>?> GetTeachers()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetTeachers";

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת TeacherModels
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<TeacherModels>? result = JsonSerializer.Deserialize<List<TeacherModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TeacherModels>?> GetAllTeachers()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetAllTeachers";

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת TeacherModels
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<TeacherModels>? result = JsonSerializer.Deserialize<List<TeacherModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<StudentModels>?> GetAllStudents()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetAllStudents";

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת StudentModels
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<StudentModels>? result = JsonSerializer.Deserialize<List<StudentModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TeacherModels>?> GetPendingTeachers()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetPendingTeachers";

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת TeacherModels
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<TeacherModels>? result = JsonSerializer.Deserialize<List<TeacherModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<LessonModels>?> GetFutureLessonsAsync()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetFutureLessons";  // נתיב ל-API שלך

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת LessonDto
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<LessonModels>? result = JsonSerializer.Deserialize<List<LessonModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;  // אם לא התקבלה תשובה תקינה
                }
            }
            catch (Exception ex)
            {
                return null;  // במקרה של שגיאה
            }
        }


        public async Task<bool> TeacherDeleteLessonAsync(int lessonId)
        {
            // קביעת כתובת ה-API לקריאהDeleteLesson
            string url = $"{this.baseUrl}TeacherDeleteLesson?lessonId={lessonId}";  // נתיב ל-API שלך

            try
            {
                // שליחת בקשת DELETE לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    return true;  // השיעור נמחק בהצלחה
                }
                else
                {
                    return false;  // אם לא התקבלה תשובה תקינה
                }
            }
            catch (Exception ex)
            {
                return false;  // במקרה של שגיאה
            }
        }


        public async Task<bool> DeleteLessonAsync(int lessonId)
        {
            // קביעת כתובת ה-API לקריאהDeleteLesson
            string url = $"{this.baseUrl}DeleteLesson?lessonId={lessonId}";  // נתיב ל-API שלך

            try
            {
                // שליחת בקשת DELETE לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    return true;  // השיעור נמחק בהצלחה
                }
                else
                {
                    return false;  // אם לא התקבלה תשובה תקינה
                }
            }
            catch (Exception ex)
            {
                return false;  // במקרה של שגיאה
            }
        }


        public async Task<List<LessonModels>?> GetPreviousLessonsAsync()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetPreviousLessons";  // נתיב ל-API שלך

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת LessonDto
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<LessonModels>? result = JsonSerializer.Deserialize<List<LessonModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;  // אם לא התקבלה תשובה תקינה
                }
            }
            catch (Exception ex)
            {
                return null;  // במקרה של שגיאה
            }
        }


        public async Task<List<LessonModels>?> GetTeacherPreviousLessonsAsync()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetTeacherPreviousLessons";  // נתיב ל-API שלך

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת LessonDto
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<LessonModels>? result = JsonSerializer.Deserialize<List<LessonModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;  // אם לא התקבלה תשובה תקינה
                }
            }
            catch (Exception ex)
            {
                return null;  // במקרה של שגיאה
            }
        }


        public async Task<List<LessonModels>?> GetTeacherFutureLessonsAsync()
        {
            // קביעת כתובת ה-API לקריאה
            string url = $"{this.baseUrl}GetTeacherFutureLessons";  // נתיב ל-API שלך

            try
            {
                // שליחת בקשת GET לשרת
                HttpResponseMessage response = await client.GetAsync(url);

                // בדיקת תקינות התגובה
                if (response.IsSuccessStatusCode)
                {
                    // קריאת התוכן כתשובה
                    string resContent = await response.Content.ReadAsStringAsync();

                    // המרת התשובה לרשימת LessonDto
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<LessonModels>? result = JsonSerializer.Deserialize<List<LessonModels>>(resContent, options);

                    return result;
                }
                else
                {
                    return null;  // אם לא התקבלה תשובה תקינה
                }
            }
            catch (Exception ex)
            {
                return null;  // במקרה של שגיאה
            }
        }

    }
}
