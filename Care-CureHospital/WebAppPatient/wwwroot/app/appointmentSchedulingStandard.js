Vue.component("appointmentSchedulingStandard", {
	data: function () {
		return {
            recommendationStep : 1,
            state : {
                disabledDates: {
                    to: new Date(),
                }
            },
            dateModel : '',
            specialization : '0',
            doctorId : '0',
            priority : '0',
            selectedAppointment: null,
            specializations: [],
            doctorsBySpecialization : [],
            doctorWorkDay : null,
            userToken: null
		}
	},
	template: `
	<div>
	
		<div class="boundary-for-scroll-appointment-scheduling-by-recommendation">
			<div class="logo-and-name-appointment-scheduling-by-recommendation">
					<div class="logo-appointment-scheduling-by-recommendation">        
						<img src="images/hospital.png"/>
					</div>
					<div class="web-name-appointment-scheduling-by-recommendation">
						<h3></h3>
					</div>  
				</div>
	 
				<div class="main-appointment-scheduling-by-recommendation">     
					<ul class="menu-contents">
                        <li class="active"><a href="#/patientAppointments">Pregledi</a></li>
                        <li><a href="#/">Utisci</a></li>
                        <li><a href="#/patientMainPage">Početna</a></li>
                        <li><a href="#/medicalRecordReview">Moj karton</a></li>
                        <li><a href="#/patientDocumentsSimpleSearch">Dokumenti</a></li>
					</ul>
				</div>
 
				<div class="dropdown">
					<button class="dropbtn">
						<img id="menuIcon" src="images/menuIcon.png" />
						<img id="userIcon" src="images/user.png" />
					</button>
				<div class="dropdown-content">
					<a href="#/userLogin" @click="logOut()">Odjavi se</a>
				</div>
			</div>
		</div>
	 
	<div class="form-for-appointment-scheduling-by-recommendation">
        <div class="form-title-appointment-scheduling-by-recommendation">
            <div v-if="this.recommendationStep === 1">
                <h1>Vremenski period termina</h1><br><br>
                <h3>Izaberite datum:</h3>
                <vuejs-datepicker v-model="dateModel" id="startDateID" name="startDate" type="date" format="dd.MM.yyyy" :disabledDates="state.disabledDates" placeholder="Izaberite datum" ></vuejs-datepicker><br><br><br><br>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button style="margin-top:48%;" type="button" @click="nextRecommendationStep()">Dalje</button>
                </div>
            </div>
            <div v-if="this.recommendationStep === 2">
                <h1 style="padding-bottom: 70px;">Specijalizacija</h1>
                <h3>Izaberite specijalističku granu:</h3>
                <select v-model="specialization" >
                    <option value="0">Izaberite specijalističku granu...</option>
                    <option v-for="s in this.specializations" :key="s.id" :value="s.id">{{ s.specialitationForDoctor }}</option>
                </select><br>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="nextRecommendationStep()" style="margin-top: 80%;">Dalje</button>
                </div>
                <div class="back-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="backRecommendationStep()">Nazad</button>
                </div>
            </div>
            <div v-if="this.recommendationStep === 3">
                <h1 style="padding-bottom: 70px;">Doktor</h1>
                <h3>Izaberite doktora:</h3>
                <select v-model="doctorId">
                    <option value="0">Izaberite doktora...</option>
                    <option v-for="d in this.doctorsBySpecialization" :key="d.id" :value="d.id">Dr {{ d.name }} {{d.surname}}</option>
                </select><br>
                <div class="next-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="nextRecommendationStep()" style="margin-top: 80%;">Dalje</button>
                </div>
                <div class="back-btn-appointment-scheduling-by-recommendation">
                    <button type="button" @click="backRecommendationStep()">Nazad</button>
                </div>
            </div>
            <div v-if="this.recommendationStep === 4">
                <div v-if="this.doctorWorkDay !== null">
                    <h1 style="padding-bottom: 30px;">Termini</h1>
                    <h3>Izaberite jedan slobodan termin:</h3><br>
                    <div class="scroll-in-appointment-scheduling-by-recommendation">
                        <div class="table-wrapper-appointment-scheduling-by-recommendation">
                            <table class="fl-table-appointment-scheduling-by-recommendation">
                                <thead>
                                <tr>
                                    <th>Vreme</th>
                                    <th>Izaberite</th>
                                </tr>
                                </thead>
                                <tbody>
                                    <tr v-for = "(avAppointment, index) in this.doctorWorkDay.availableAppointments">
                                        <td>{{avAppointment.startTime.split('T')[1]}} - {{avAppointment.endTime.split('T')[1]}}</td>
                                        <td><input v-model="selectedAppointment" type="radio" name="radioButtonAppointment" :value="index"></td>	
                                    </tr>       
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="next-btn-appointment-scheduling-by-recommendation">
                        <button type="button" @click="scheduleTerm()" style="margin-top: 14%;">Zakaži</button>
                    </div>
                    <div class="back-btn-appointment-scheduling-by-recommendation" style="margin-top: -19.2%;">
                        <button type="button" @click="backRecommendationStep()">Nazad</button>
                    </div>
                </div>
                <div v-else>
                    <h1 style="padding-bottom: 30px;" v-if="this.priority === '1'">Preporučeni termini po doktoru</h1>
                    <h1 style="padding-bottom: 30px;" v-if="this.priority === '2'">Preporučeni termini po vremenskom periodu</h1>
                    <h3>Nema slobodnih termina za izabranog doktora i datum!</h3><br>
                    <div class="back-btn-appointment-scheduling-by-recommendation" style="margin-top: 49%;">
                        <button type="button" @click="backRecommendationStep()">Nazad</button>
                    </div>
                </div>

            </div>
            
        </div>
    </div>

	 <div class="verticalLinePublishFeedback"></div>
	
	 <div class="sideComponents">      
         <ul class="ulForSideComponents">
         <div><li><a href="#/patientAppointments">Moji pregledi</a></li></div><br/>
         <div><li class="active"><a href="#/appointmentSchedulingStandard">Obično zakazivanje</a></li></div><br/>
         <div><li><a href="#/appointmentSchedulingByRecommendation">Preporuka termina</a></li></div><br/>
	     </ul>
	 </div>
	 	  
	</div>
        
    `   
    ,
	components : {
		vuejsDatepicker
    }
    ,
    computed : {	
		newDateStart() { 		
			if(this.startDateModel !== ''){
				return {
		            to: moment(this.startDateModel).startOf('day').add(1, 'days').toDate()
		        }
            }
		}		
	},
	methods: {
        nextRecommendationStep : function() {
            if(this.recommendationStep === 1 && this.dateModel !== ''){
                this.recommendationStep += 1;
            } else if (this.recommendationStep === 1 && this.dateModel === '') {
                toast('Morate izabrati datum')
            } else if (this.recommendationStep === 2 && this.specialization !== '0') {
                this.recommendationStep += 1;
                axios.get('api/doctor/getAllDoctorBySpecializationId/' + this.specialization, { 
                    headers: { 'Authorization': 'Bearer ' + this.userToken }
                }).then(response => {
                    this.doctorsBySpecialization = response.data;
                }).catch(error => {
                    if (error.response.status === 401 || error.response.status === 403) {
                        toast('Nemate pravo pristupa stranici!')
                        this.$router.push({ name: 'userLogin' })
                    }
                });
            } else if (this.recommendationStep === 2 && this.specialization === '0') {
                toast('Morate izabrati specijalističku granu')
            } else if (this.recommendationStep === 3 && this.doctorId !== '0') {
                this.recommendationStep += 1;
                axios.get('api/appointment/getAvailableAppointments', {
                    params: {
                        doctorId: this.doctorId,
                        date: this.convertDate(this.dateModel)
                    } }, {
                    headers: { 'Authorization': 'Bearer ' + this.userToken }
                }).then(response => {
                    this.doctorWorkDay = response.data;
				}).catch(error => {
                    if (error.response.status === 401 || error.response.status === 403) {
                        toast('Nemate pravo pristupa stranici!')
                        this.$router.push({ name: 'userLogin' })
                    }
                    else {
                        this.doctorWorkDay = null;
                    }
                });
            } else if (this.recommendationStep === 3 && this.doctorId === '0') {
                toast('Morate izabrati doktora')
            }   
        },
        backRecommendationStep : function() {
            if(this.recommendationStep >= 2) {
                this.recommendationStep -= 1;
            }
        },
        scheduleTerm : function() {
            if(this.selectedAppointment === null){
                toast('Morate selektovati neki od ponuđenih termina')
            } else {
                axios.post('/api/appointment', {
                    canceled: false,
                    startTime: this.doctorWorkDay.availableAppointments[this.selectedAppointment].startTime,
                    endTime: this.doctorWorkDay.availableAppointments[this.selectedAppointment].endTime,
					doctorWorkDayId: this.doctorWorkDay.id,
					medicalExamination: {
                        shortDescription : '',
                        urgency : false,
                        roomId : this.doctorWorkDay.roomId,
                        doctorId : this.doctorWorkDay.doctorId
                    }
                }, { 
                    headers: { 'Authorization': 'Bearer ' + this.userToken }
                }).then(response => {
                    if (response.status === 200) {
                        toast('Termin je uspešno zakazan!')
                        this.resetData()
                        this.$router.push('patientAppointments')
                    }
                }).catch(error => {
                    if (error.response.status === 401 || error.response.status === 403) {
                        toast('Nemate pravo pristupa stranici!')
                        this.$router.push({ name: 'userLogin' })
                    }
                    else if (error.response.status === 404) {
                        toast('Greška prilikom zakazivanja termina!')
                    }
                });          
            }
        },
        extractTime : function(dateTime) {
            let parts = dateTime.split('T');
            return parts[1];
        },
        convertDate : function(date) {
            let d = new Date(date);
            let year = d.getFullYear();
            let month = d.getMonth() + 1;
            let day = d.getDate(); 
            return d.getFullYear() + '-' + (month > 9 ? '' : '0') + month + '-' + (day > 9 ? '' : '0') + day;
        },
        resetData : function(){
            this.recommendationStep = 1;
            this.startDateModel = '';
            this.endDateModel = '';
            this.specialization = '0';
            this.doctors = '0';
            this.priority = '0';
            this.selectedAppointment = null;
        },
        logOut: function () {
            localStorage.removeItem("validToken");
        }
	},
	mounted() {
        this.userToken = localStorage.getItem('validToken');

        axios.get('api/doctor/getAllSpecialization', { 
            headers: { 'Authorization': 'Bearer ' + this.userToken }
        }).then(response => {
            this.specializations = response.data;
        }).catch(error => {
			if (error.response.status === 401 || error.response.status === 403) {
				toast('Nemate pravo pristupa stranici!')
				this.$router.push({ name: 'userLogin' })
			}
		});
	}

});