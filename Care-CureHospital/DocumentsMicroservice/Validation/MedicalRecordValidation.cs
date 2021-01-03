using DocumentsMicroservice.Dto;
using DocumentsMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Validation
{
    public class MedicalRecordValidation
    {
        private Regex usernameRegex = new Regex(@"^[A-Za-zŠšĐđŽžČčĆć][A-Za-z0-9ŠšĐđŽžČčĆć]*$");
        private Regex lettersOnlyRegex = new Regex(@"^[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*$");
        private Regex jmbgRegex = new Regex(@"^[0-9]{13}$");
        private Regex personalCardRegex = new Regex(@"^[0-9]{9}$");
        private Regex healthInsuranceCardRegex = new Regex(@"^[0-9]{11}$");
        private Regex contactNumberRegex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
        private Regex eMailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

        private IPatientService patientService;

        public MedicalRecordValidation(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public bool ValidateMedicalRecord(MedicalRecordDto medicalRecordDto)
        {
            if (!ValidateUsername(medicalRecordDto.Patient.Username) || !ValidatePassword(medicalRecordDto.Patient.Password, medicalRecordDto.ConfirmedPassword)
                || !ValidateLettersOnly(medicalRecordDto) || !ValidateJmbg(medicalRecordDto.Patient.Jmbg) || !ValidateIdentityCard(medicalRecordDto.Patient.IdentityCard)
                || !ValidateHealthInsuranceCard(medicalRecordDto.Patient.HealthInsuranceCard) || !ValidateDateOfBirth(medicalRecordDto.Patient.DateOfBirth)
                || !ValidateContactNumber(medicalRecordDto.Patient.ContactNumber) || !ValidateEMail(medicalRecordDto.Patient.EMail) || !EmptyAddress(medicalRecordDto))
            {
                return false;
            }
            return true;
        }

        private bool ValidateUsername(string username)
        {
            if (!BasicValidation.ValidateString(username, usernameRegex))
            {
                return false;
            }
            else if (this.patientService.DoesUsernameExist(username))
            {
                return false;
            }
            return true;
        }

        private bool ValidatePassword(string password, string confirmedPassword)
        {
            if (!BasicValidation.CheckIfStringIsEmptyOrNull(password) || !BasicValidation.CheckIfStringIsEmptyOrNull(confirmedPassword))
            {
                return false;
            }
            else if (!password.Equals(confirmedPassword))
            {
                return false;
            }
            return true;
        }

        private bool ValidateLettersOnly(MedicalRecordDto dto)
        {
            if (!BasicValidation.ValidateString(dto.Patient.Name, lettersOnlyRegex)
                || !BasicValidation.ValidateString(dto.Patient.ParentName, lettersOnlyRegex)
                    || !BasicValidation.ValidateString(dto.Patient.Surname, lettersOnlyRegex))
            {
                return false;
            }
            return true;
        }

        private bool ValidateJmbg(string jmbg)
        {
            return BasicValidation.ValidateString(jmbg, jmbgRegex);
        }

        private bool ValidateIdentityCard(string identityCard)
        {
            return BasicValidation.ValidateString(identityCard, personalCardRegex);
        }

        private bool ValidateHealthInsuranceCard(string healthInsuranceCard)
        {
            return BasicValidation.ValidateString(healthInsuranceCard, healthInsuranceCardRegex);
        }

        private bool ValidateContactNumber(string contactNumber)
        {
            return BasicValidation.ValidateString(contactNumber, contactNumberRegex);
        }

        private bool ValidateEMail(string eMail)
        {
            return BasicValidation.ValidateString(eMail, eMailRegex);
        }

        private bool EmptyAddress(MedicalRecordDto medicalRecordDto)
        {
            if (!BasicValidation.CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.Name)
                || !BasicValidation.CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.PostCode.ToString())
                    || !BasicValidation.CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.Address)
                        || !BasicValidation.CheckIfStringIsEmptyOrNull(medicalRecordDto.Patient.City.Country.Name))
            {
                return false;
            }
            return true;
        }

        private bool ValidateDateOfBirth(DateTime dateOfBirth)
        {
            return BasicValidation.CheckIfStringIsEmptyOrNull(dateOfBirth.ToString());
        }
    }
}
