/***********************************************************************
 * Module:  IssueMedicamentsService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.ExaminationSurgeryServices.IssueMedicamentsService
 ***********************************************************************/

using Model.Doctor;
using Service.MedicamentService;
using System;
using System.Collections.Generic;

namespace Controller.MedicamentControlers
{
    public class IssueMedicamentsController : IController<IssueOfMedicaments, int>
    {
        public IssueMedicamentsService issueMedicamentsService;

        public IssueMedicamentsController(IssueMedicamentsService issueMedicamentsService)
        {
            this.issueMedicamentsService = issueMedicamentsService;
        }

        public IssueOfMedicaments GetEntity(int id)
        {
            return issueMedicamentsService.GetEntity(id);
        }

        public IEnumerable<IssueOfMedicaments> GetAllEntities()
        {
            return issueMedicamentsService.GetAllEntities();
        }

        public IssueOfMedicaments AddEntity(IssueOfMedicaments entity)
        {
            return issueMedicamentsService.AddEntity(entity);
        }

        public void UpdateEntity(IssueOfMedicaments entity)
        {
            issueMedicamentsService.UpdateEntity(entity);
        }

        public void DeleteEntity(IssueOfMedicaments entity)
        {
            issueMedicamentsService.DeleteEntity(entity);
        }

    }
}