using Backend.Model.BlogAndNotification;
using Backend.Model.DoctorMenager;
using Backend.Model.PatientDoctor;
using Backend.Model.Pharmacy;
using Backend.Repository.BlogNotificationRepository;
using Backend.Repository.DirectorRepository;
using Backend.Repository.DoctorRepository;
using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Repository.MySQL.Stream;
using Backend.Repository.PharmacyRepository;
using Backend.Repository.UsersRepository;
using Backend.Service.BlogNotificationServices;
using Backend.Service.DirectorService;
using Backend.Service.DoctorService;
using Backend.Service.EmailService;
using Backend.Service.ExaminationSurgeryServices;
using Backend.Service.PharmaciesService;
using Backend.Service.RequestServices;
using Backend.Service.SftpService;
using Backend.Service.UsersServices;
using Model.AllActors;
using Model.Doctor;
using Model.Patient;
using Model.PatientDoctor;
using Model.Term;
using Repository.ExaminationSurgeryRepository;
using Repository.IDSequencer;
using Repository.MedicalRecordRepository;
using Repository.RoomsRepository;
using Repository.UsersRepository;
using Service.ExaminationSurgeryServices;
using Service.MedicalRecordService;
using Service.RoomsServices;
using Service.UsersServices;

namespace Backend
{
    public class App
    {
        private static App _instance = null;

        public SurveyService SurveyService;
        public QuestionService QuestionService;
        public AnswerService AnswerService;
        public PatientFeedbackService PatientFeedbackService;
        public MedicalExaminationService MedicalExaminationService; 
        public MedicalExaminationReportService MedicalExaminationReportService;
        public PrescriptionService PrescriptionService;
        public MedicalRecordService MedicalRecordService;
        public AllergiesService AllergiesService;
        public PatientService PatientService;
        public DoctorService DoctorService;
        public ReportService ReportService;
        public EmailVerificationService EmailVerificationService;
        public DoctorWorkDayService DoctorWorkDayService;
        public SpetialitationService SpetialitationService;
        public AppointmentService AppointmentService;
        public EPrescriptionService EPrescriptionService;
        public PharmacyService PharmacyService;
        public RoomService RoomService;
        public ManagerService ManagerService;
        public SecretaryService SecretaryService;
        public SftpService SftpService;
        public SystemAdministratorService SystemAdministratorService;
        public UserService UserService;
        public HttpService HttpService;
        public TenderService TenderService;

        private App()
        {
            EmailVerificationService = new EmailVerificationService();
            SftpService = new SftpService();
            HttpService = new HttpService();
            TenderService = new TenderService();
            MedicalExaminationService = new MedicalExaminationService(
                new MedicalExaminationRepository(new MySQLStream<MedicalExamination>(), new IntSequencer()));
            PatientFeedbackService = new PatientFeedbackService(
                new PatientFeedbackRepository(new MySQLStream<PatientFeedback>(), new IntSequencer()));
            MedicalExaminationReportService = new MedicalExaminationReportService(
               new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>(), new IntSequencer()));
            PrescriptionService = new PrescriptionService(
               new PrescriptionRepository(new MySQLStream<Prescription>(), new IntSequencer()));
            MedicalRecordService = new MedicalRecordService(
               new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new IntSequencer()), EmailVerificationService);
            QuestionService = new QuestionService(
                new QuestionRepository(new MySQLStream<Question>(), new IntSequencer()));
            AnswerService = new AnswerService(
                new AnswerRepository(new MySQLStream<Answer>(), new IntSequencer()), QuestionService);
            AllergiesService = new AllergiesService(
               new AllergiesRepository(new MySQLStream<Allergies>(), new IntSequencer()));
            PatientService = new PatientService(
               new PatientRepository(new MySQLStream<Patient>(), new IntSequencer()));
            SurveyService = new SurveyService(
               new SurveyRepository(new MySQLStream<Survey>(), new IntSequencer()), MedicalExaminationService, AnswerService);
            DoctorService = new DoctorService(
                new DoctorRepository(new MySQLStream<Doctor>(), new IntSequencer()));
            ReportService = new ReportService(
               new ReportRepository(new MySQLStream<Report>(), new IntSequencer()), SftpService);
            DoctorWorkDayService = new DoctorWorkDayService(
                new DoctorWorkDayRepository(new MySQLStream<DoctorWorkDay>(), new IntSequencer()), DoctorService);
            SpetialitationService = new SpetialitationService(
                new SpecialitationRepository(new MySQLStream<Specialitation>(), new IntSequencer()));
            AppointmentService = new AppointmentService(
                new AppointmentRepository(new MySQLStream<Appointment>(), new IntSequencer()), PatientService);
            EPrescriptionService = new EPrescriptionService(
                new EPrescriptionRepository(new MySQLStream<EPrescription>(), new IntSequencer()), SftpService);
            PharmacyService = new PharmacyService(
               new PharmacyRepository(new MySQLStream<Pharmacies>(), new IntSequencer()));
            RoomService = new RoomService(
               new RoomRepository(new MySQLStream<Room>(), new IntSequencer()));
            ManagerService = new ManagerService(
                new ManagerRepository(new MySQLStream<Manager>(), new IntSequencer()));
            SecretaryService = new SecretaryService(
                new SecretaryRepository(new MySQLStream<Secretary>(), new IntSequencer()));
            SystemAdministratorService = new SystemAdministratorService(
                new SystemAdministratorRepository(new MySQLStream<SystemAdministrator>(), new IntSequencer()));
            UserService = new UserService(
                new UserRepository(new MySQLStream<User>(), new IntSequencer()), PatientService, SystemAdministratorService);
        }

        public static App Instance()
        {
            if (_instance == null)
            {
                _instance = new App();
            }
            return _instance;
        }
    }
}
