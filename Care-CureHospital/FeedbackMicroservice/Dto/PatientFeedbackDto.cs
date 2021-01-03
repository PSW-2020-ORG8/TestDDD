using Model.AllActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Dto
{
    public class PatientFeedbackDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsForPublishing { get; set; }
        public bool IsPublished { get; set; }
        public bool IsAnonymous { get; set; }
        public int PatientId { get; set; }
        public string Patient { get; set; }
        public string PublishingDate { get; set; }
        public PatientFeedbackDto() { }
    }
}
