// Khái báo chỉ số
public class Koi
{
    public string Breed { get; set; } // Chủng loại
    public double Size { get; set; } // Kích thước (cm)
    public int Age { get; set; } // Độ tuổi (tháng)
    public string Color { get; set; } // Màu sắc
    public bool IsHealthy { get; set; } // Tình trạng

    public Koi(string breed, double size, int age, string color, bool isHealthy)
    {
        Breed = breed;
        Size = size;
        Age = age;
        Color = color;
        IsHealthy = isHealthy;
    }
}
// tạo đơn xét duyệt
public class KoiRegistration
{
    public int Id { get; set; }
    public Koi Koi { get; set; }
    public string Status { get; set; } // Pending, Approved, Rejected
    public DateTime SubmissionDate { get; set; }

    public KoiRegistration(Koi koi, int id)
    {
        Koi = koi;
        Status = "Pending";
        SubmissionDate = DateTime.Now;
        Id = id;
    }
}
// Hệ thống phân loiạ cá 
public class KoiClassifier
{
    public string ClassifyKoi(Koi koi)
    {
        if (!koi.IsHealthy)
        {
            return "Disqualified";
        }
        if (koi.Breed == "Sanke" && koi.Size >= 70 && koi.Age >= 24)
        {
            return "Grand Champion";
        }
        else if (koi.Size >= 50 && koi.Age >= 12)
        {
            return "Champion";
        }
        else if (koi.Age < 6)
        {
            return "Baby Champion";
        }

        return "Participant";
    }
}
// Hệ thống xét duyệt cá
public class KoiRegistrationService
{
    private static List<KoiRegistration> registrations = new List<KoiRegistration>();
    private static int nextId = 1;

    public KoiRegistration RegisterKoi(Koi koi)
    {
        var registration = new KoiRegistration(koi, nextId++);
        registrations.Add(registration);
        return registration;
    }

    public List<KoiRegistration> GetAllRegistrations()
    {
        return registrations;
    }

    public KoiRegistration ApproveRegistration(int id)
    {
        var registration = registrations.FirstOrDefault(r => r.Id == id);
        if (registration != null)
        {
            registration.Status = "Approved"; // được vào
        }
        return registration;
    }

    public KoiRegistration RejectRegistration(int id)
    {
        var registration = registrations.FirstOrDefault(r => r.Id == id);
        if (registration != null)
        {
            registration.Status = "Rejected"; // cút
        }
        return registration;
    }
}
