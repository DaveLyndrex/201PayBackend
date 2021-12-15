/*[10/05/2021] CN E.Patot*/
/*[10/07/2021] CN E.Patot*/
/*[10/14/2021] CN E.Patot*/
using BackEnd.Models;
using BackEnd.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class MasterFileController : ApiController
    {
        public ResponseModel response = new ResponseModel();
        
        // Get All Suffix 
        [HttpGet, AllowAnonymous, Route("api/getAllSuffixes")]
        public async Task<IHttpActionResult> getSuffixSetup()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllSuffixSetup();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Prefix 
        [HttpGet, AllowAnonymous, Route("api/getAllPrefixes")]
        public async Task<IHttpActionResult> getPrefixSetup()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllPrefix();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        // Get All Bank 
        [HttpGet, AllowAnonymous, Route("api/getAllBanks")]
        public async Task<IHttpActionResult> getBanks()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllBanks();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Regularization PA 
        [HttpGet, AllowAnonymous, Route("api/getRegularizationPA")]
        public async Task<IHttpActionResult> getRegularizationPA()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getRegularizationPA();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Dependent Type
        [HttpGet, AllowAnonymous, Route("api/getDependentsType")]
        public async Task<IHttpActionResult> getDependentsType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getDependentsType();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Blood Type 
        [HttpGet, AllowAnonymous, Route("api/getAllBloodTypes")]
        public async Task<IHttpActionResult> getBloodType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllBloodTypes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All GPA 
        [HttpGet, AllowAnonymous, Route("api/getAllGPAS")]
        public async Task<IHttpActionResult> getAllGPA()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllGPA();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

       
        // Get All Company Setup 
        [HttpGet, AllowAnonymous, Route("api/getAllCompanySetup")]
        public async Task<IHttpActionResult> getCompanySetup()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getCompanySetup();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Custom Fields 
        [HttpGet, AllowAnonymous, Route("api/getAllCustomFields")]
        public async Task<IHttpActionResult> getCustomFields()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getCustomFields();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Civil Status
        [HttpGet, AllowAnonymous, Route("api/getAllCivilStatus")]
        public async Task<IHttpActionResult> getCivilStatus()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getCivilStatus();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }


        // Get All Country
        [HttpGet, AllowAnonymous, Route("api/getAllCountries")]
        public async Task<IHttpActionResult> getCountry()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getCountry();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Department Setup
        [HttpGet, AllowAnonymous, Route("api/getAllDepartments")]
        public async Task<IHttpActionResult> getDepartmentSetup()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getDepartmentSetup();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));

        }
        // Get All Employee Status 
        [HttpGet, AllowAnonymous, Route("api/getAllEmployeeStatus")]
        public async Task<IHttpActionResult> getAllEmployeeStatus()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getEmployeeStatus();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Job Levels 
        [HttpGet, AllowAnonymous, Route("api/getAllJobLevels")]
        public async Task<IHttpActionResult> getAllJobLevel()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getJobLevels();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Job Category 
        [HttpGet, AllowAnonymous, Route("api/getAllJobCategories")]
        public async Task<IHttpActionResult> getAllJobCategory()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getJobCategories();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Designations 
        [HttpGet, AllowAnonymous, Route("api/getAllDesignations")]
        public async Task<IHttpActionResult> getAllDesignation()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getDesignation();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Location 
        [HttpGet, AllowAnonymous, Route("api/getAllLocations")]
        public async Task<IHttpActionResult> getAllLocation()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getLocations();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Region 
        [HttpGet, AllowAnonymous, Route("api/getAllRegions")]
        public async Task<IHttpActionResult> getAllRegion()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getRegion();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Site 
        [HttpGet, AllowAnonymous, Route("api/getAllSites")]
        public async Task<IHttpActionResult> getAllSite()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getSites();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Projects 
        [HttpGet, AllowAnonymous, Route("api/getAllProjects")]
        public async Task<IHttpActionResult> getAllProject()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getProjects();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Reason 
        [HttpGet, AllowAnonymous, Route("api/getAllReasons")]
        public async Task<IHttpActionResult> getAllReason()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getReasons();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All BusinessUnit 
        [HttpGet, AllowAnonymous, Route("api/getAllBusinessUnits")]
        public async Task<IHttpActionResult> getAllBusinessUnit()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getBusinessUnits();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Job Family Name 
        [HttpGet, AllowAnonymous, Route("api/getAllJobFamilyNames")]
        public async Task<IHttpActionResult> getAllJobFamilyName()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getJobFamilyNames();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Job Code 
        [HttpGet, AllowAnonymous, Route("api/getAllJobCodes")]
        public async Task<IHttpActionResult> getAllJobCode()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getJobCodes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Employment Type 
        [HttpGet, AllowAnonymous, Route("api/getAllEmploymentType")]
        public async Task<IHttpActionResult> getEmploymentType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getEmploymentType();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Division 
        [HttpGet, AllowAnonymous, Route("api/getAllDivision")]
        public async Task<IHttpActionResult> getDivisions()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getDivisions();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Grades 
        [HttpGet, AllowAnonymous, Route("api/getAllGrades")]
        public async Task<IHttpActionResult> getAllGrades()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getGrades();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All GradeRates 
        [HttpGet, AllowAnonymous, Route("api/getAllGradeRates")]
        public async Task<IHttpActionResult> getAllGradeRates()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getGradeRates();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All GPA 
        [HttpGet, AllowAnonymous, Route("api/getAllWorkerTypes")]
        public async Task<IHttpActionResult> getAllWorkerTypes()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getWorkerTypes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All PayrollGroup
        [HttpGet, AllowAnonymous, Route("api/getAllPayrollGroup")]
        public async Task<IHttpActionResult> getAllPayrollGroup()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getPayrollGroups();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Timekeeping
        [HttpGet, AllowAnonymous, Route("api/getAllTimekeeping")]
        public async Task<IHttpActionResult> getAllTimekeeping()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getTimekeepings();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Tax Status
        [HttpGet, AllowAnonymous, Route("api/getAllTaxStatus")]
        public async Task<IHttpActionResult> getAllTaxStatus()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getTaxStatus();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Default Pay Frequency
        [HttpGet, AllowAnonymous, Route("api/getAllDefaultPayFrequency")]
        public async Task<IHttpActionResult> getAllDefaultPayFrequency()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getDefaultPayFrequency();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Shift Set
        [HttpGet, AllowAnonymous, Route("api/getAllShiftSet")]
        public async Task<IHttpActionResult> getAllShiftSet()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getShiftSets();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Payroll Deduction
        [HttpGet, AllowAnonymous, Route("api/getAllPayDeduction")]
        public async Task<IHttpActionResult> getAllPayDeduction()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllPayDeduction();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Paycodes Setup
        [HttpGet, AllowAnonymous, Route("api/getAllPayCodes")]
        public async Task<IHttpActionResult> getAllPayCodes()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllPayCodes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Pay Rates
        [HttpGet, AllowAnonymous, Route("api/getAllPayRates")]
        public async Task<IHttpActionResult> getAllPayRates()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllPayRates();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Payroll Period
        [HttpGet, AllowAnonymous, Route("api/getAllPayrollPeriod")]
        public async Task<IHttpActionResult> getAllPayrollPeriod()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getPayrollPeriodSetup();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Default Currency
        [HttpGet, AllowAnonymous, Route("api/getAllDefaultCurrency")]
        public async Task<IHttpActionResult> getAllDefaultCurrency()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getDefaultCurrency();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Training Types
        [HttpGet, AllowAnonymous, Route("api/getAllTrainingTypes")]
        public async Task<IHttpActionResult> getAllTrainingTypes ()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getTrainingTypes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Leave Types
        [HttpGet, AllowAnonymous, Route("api/getAllLeaveTypes")]
        public async Task<IHttpActionResult> getAllLeaveTypes()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getLeaveTypes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Ethnicity
        [HttpGet, AllowAnonymous, Route("api/getAllEthnicity")]
        public async Task<IHttpActionResult> getAllEthnicity()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getEthnicity();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Leave Credit Years
        [HttpGet, AllowAnonymous, Route("api/getAllLeaveCreditYears")]
        public async Task<IHttpActionResult> getAllLeaveCreditYears()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getLeaveCreditYears();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Visa Permit Type
        [HttpGet, AllowAnonymous, Route("api/getAllVisaPermitType")]
        public async Task<IHttpActionResult> getAllVisaPermitType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getVisaPermitType();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Visa Permit Type
        [HttpGet, AllowAnonymous, Route("api/getAllPhoneType")]
        public async Task<IHttpActionResult> getAllPhoneType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.GetPhoneType();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));

        }
        // Get All Citizenship Status
        [HttpGet, AllowAnonymous, Route("api/getAllCitizenshipStatus")]
        public async Task<IHttpActionResult> getAllCitizenshipStatus()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getCitizenshipStatus();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Approver Groups
        [HttpGet, AllowAnonymous, Route("api/getAllApproverGroups")]
        public async Task<IHttpActionResult> getAllApproverGroups()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllApproverGroups();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Approver Groups
        [HttpGet, AllowAnonymous, Route("api/getAllApprovalGroups")]
        public async Task<IHttpActionResult> getAllApprovalGroups()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllApprovalGroups();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
        // Get All Approver and Rater
        [HttpGet, AllowAnonymous, Route("api/getAllApproverAndRater")]
        public async Task<IHttpActionResult> getAllApproverAndRater()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllApproverAndRater();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Sex
        [HttpGet, AllowAnonymous, Route("api/getAllSex")]
        public async Task<IHttpActionResult> getAllSex()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllSex();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Cost Center
        [HttpGet, AllowAnonymous, Route("api/getAllCostCenterSetup")]
        public async Task<IHttpActionResult> getCostCenter()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getCostCenter();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Cost Center
        [HttpGet, AllowAnonymous, Route("api/getAllDefaultCostCenterType")]
        public async Task<IHttpActionResult> getCostCenterType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getCostCenterType();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Cost Center
        [HttpGet, AllowAnonymous, Route("api/getAllDefaultAddressType")]
        public async Task<IHttpActionResult> getAllDefaultAddressType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllDefaultAddressTypes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }


        // Get All DMAccount
        [HttpGet, AllowAnonymous, Route("api/getAllDMAccount")]
        public async Task<IHttpActionResult> getAllDMAccount()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllDMAccount();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }

        // Get All Default Pay Component Type
        [HttpGet, AllowAnonymous, Route("api/getAllDefaultPayComponentType")]
        public async Task<IHttpActionResult> getAllDefaultPayComponentType()
        {
            MasterFileService mfs = new MasterFileService();

            var result = mfs.getAllDefaultPayComponentTypes();
            var encrypted_data = new EncryptedDataModel { ciphertext = Encryptor.EncryptStringToBytes(Encryptor.ObjectToJsonString(result)) };
            return Ok(await Task.Run(() => encrypted_data));
        }
    }
}
