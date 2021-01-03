

using Model.AllActors;
using Model.Term;


namespace HospitalMap.Controller
{
    public class InformationEditController
    {


        
        

        public InformationEditController() {

            
             }

         public void UpdateEntity(Room room)
        {
            Backend.App.Instance().RoomService.UpdateEntity(room);
        }

        public Room GetEntity(int id)
        {
           return Backend.App.Instance().RoomService.GetEntity(id);
        }

        public Room GetRoomById(string roomId)
        {
            return Backend.App.Instance().RoomService.GetEntityByHospitalId(roomId);
        }


        public Doctor GetDoctorById(int id)
        {
            return Backend.App.Instance().DoctorService.GetEntity(id);
        }

          

    }
}
