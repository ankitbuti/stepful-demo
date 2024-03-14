namespace StepfulLib;

public class Bootstrap
{
    public static List<Student> GenerateStudents()
    {
        List<Student> students = new List<Student>
        {
            new Student
            {
                FullName = "Emma Watson",
                Email = "emma@student-email1.com",
                PhoneNumber = "123-001-0001",
                ProfilePicUrl = "https://ca-times.brightspotcdn.com/dims4/default/4267da5/2147483647/strip/true/crop/6284x4189+0+0/resize/1200x800!/quality/75/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2Fb2%2Fa6%2F43e44f1342ce9d40026058e31a04%2Fbritain-bafta-film-awards-2022-arrivals-55382.jpg"
            },
            new Student
            {
                FullName = "Tom Cruise",
                Email = "tom@student-email2.com",
                PhoneNumber = "123-002-0002",
                ProfilePicUrl = "https://images.hellomagazine.com/horizon/landscape/13bd17120306-tom-cruise.jpg"
            },
            new Student
            {
                FullName = "Brad Pitt",
                Email = "brad@student-email3.com",
                PhoneNumber = "123-003-0003",
                ProfilePicUrl = "https://a57.foxnews.com/static.foxnews.com/foxnews.com/content/uploads/2023/07/1200/675/brad-pitt.jpg"
            },
            new Student
            {
                FullName = "Jennifer Lawrence",
                Email = "jennifer@student-email4.com",
                PhoneNumber = "123-004-0004",
                ProfilePicUrl = "https://akns-images.eonline.com/eol_images/Entire_Site/202359/rs_1024x759-230609125434-1024-jennifer-lawrence-cannes-2023.jpg"
            },
            new Student
            {
                FullName = "Anne Hathway",
                Email = "anne@student-email5.com",
                PhoneNumber = "123-005-0005",
                ProfilePicUrl = "https://media.glamour.com/photos/635c28f90685c39950d7fe9b/4:3/w_2080,h_1560,c_limit/ANNEHATHAWAYMOVIE%20281022%20defult-land-GettyImages-1243944981.jpg"
            },
            new Student
            {
                FullName = "George Clooney",
                Email = "george@student-email6.com",
                PhoneNumber = "123-006-0006",
                ProfilePicUrl = "https://cdn.britannica.com/33/196233-050-169795DF/George-Clooney-2016.jpg"
            }
        };

        return students;
    }

    public static List<Coach> GenerateCoaches()
    {
        List<Coach> coaches = new List<Coach>
        {
            new Coach
            {
                FullName = "Edoardo Serra",
                Email = "edo@coach-email1.com",
                PhoneNumber = "765-001-0001",
                ProfilePicUrl = "https://assets-global.website-files.com/60fae2951956f769f1d6018e/6463df5ecdf9e95190472b9a_IMG_9617-p-500.jpg"
            },
            new Coach
            {
                FullName = "Emmanuel Chiappini",
                Email = "emmanuel@coach-email2.com",
                PhoneNumber = "765-002-0002",
                ProfilePicUrl = "https://assets-global.website-files.com/60fae2951956f769f1d6018e/6463de65bbe4e8408c4d1cf9_IMG_9646-p-500.jpg"
            },
            new Coach
            {
                FullName = "Wyatt Ades",
                Email = "wyatt@coach-email3.com",
                PhoneNumber = "765-003-0003",
                ProfilePicUrl = "https://assets-global.website-files.com/60fae2951956f769f1d6018e/6463ddbad1b7a72632383d07_IMG_9625-p-500.jpg"
            },
            new Coach
            {
                FullName = "Wen Lee",
                Email = "wen@coach-email4.com",
                PhoneNumber = "765-004-0004",
                ProfilePicUrl = "https://assets-global.website-files.com/60fae2951956f769f1d6018e/64cbc60b1315d5bcb862f9af_wen-p-500.png"
            },
            new Coach
            {
                FullName = "Dwanda Conner",
                Email = "dwanda@coach-email5.com",
                PhoneNumber = "765-005-0005",
                ProfilePicUrl = "https://assets-global.website-files.com/60fae2951956f769f1d6018e/6407849d0bfd906233d520f1_Dwanda_Photo.png"
            },
            new Coach
            {
                FullName = "Jolene Shannon",
                Email = "jolene@coach-email6.com",
                PhoneNumber = "765-006-0006",
                ProfilePicUrl = "https://assets-global.website-files.com/60fae2951956f769f1d6018e/640785f5eb00835ad31501c1_Jolene%20Shannon-p-500.jpg"
            }
        };

        return coaches;
    }
}
