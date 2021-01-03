Vue.component("patientDocumentsSimpleSearch", {
	data: function () {
		return {
			patientDocuments: [],
			firstSearchParams: 'Doktoru',
			firstInput: '',
			prescriptionDoctorInput: '',
			prescriptionDateInput: '',
			prescriptionCommentInput: '',
			prescriptionMedicamentsInput: '',
			reportDoctorInput: '',
			reportDateInput: '',
			reportCommentInput: '',
			reportRoomInput: '',
			publishingDate: '',
			firstResult: [],
			reportsButtonSelected : true,
			prescriptionsButtonSelected : false,
			reportsResult: [],
			prescriptionsResult: [],
			userToken: null
		}
	},
	template: `
	<div>
	
	 <div class="boundaryForScroll">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="images/hospital.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
				<li><a href="#/patientAppointments">Pregledi</a></li>
				<li><a href="#/">Utisci</a></li>
				<li><a href="#/patientMainPage">Početna</a></li>
				<li><a href="#/medicalRecordReview">Moj karton</a></li>
				<li class="active"><a href="#/patientDocumentsSimpleSearch">Dokumenti</a></li>
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

	<div class="patients-docs-simple-search" style="height: 380px;">
            <div class="form-title-search">
				<h1>Pretraži po:</h1>

				<div class="reports-btn" v-if="this.reportsButtonSelected === true">
					<button type="button" @click="reportsSearchButton" style="background-color:#054f5294">Izveštaji</button>
				</div>
				<div class="reports-btn" v-if="this.reportsButtonSelected === false">
					<button type="button" @click="reportsSearchButton">Izveštaji</button>
				</div>
				<div class="prescriptions-btn" v-if="this.prescriptionsButtonSelected === true">
					<button type="button" @click="prescriptionsSearchButton" style="background-color:#054f5294">Recepti</button>
				</div>
				<div class="prescriptions-btn" v-if="this.prescriptionsButtonSelected === false">
					<button type="button" @click="prescriptionsSearchButton">Recepti</button>
				</div>

				<template v-if="this.reportsButtonSelected === true">

					Doktoru: <input v-model="reportDoctorInput" type="text" style="width:250px;margin-left:42px;" placeholder=""><br>
					Datumu:	<input v-model="reportDateInput" type="date" style="width:248px; height:42px; margin-left:43px;" placeholder=""><br>
					Sadržaju: <input v-model="reportCommentInput" type="text" style="width:250px; margin-left:40px;" placeholder=""><br>
					Sobi: <input v-model="reportRoomInput" type="text" style="width:250px; margin-left:70px; margin-top:0px" placeholder="">

				</template>

				<template v-if="this.prescriptionsButtonSelected === true">

					Doktoru: <input v-model="prescriptionDoctorInput" type="text" style="width:250px;margin-left:42px;" placeholder=""><br>
					Datumu:	<input v-model="prescriptionDateInput" type="date" style="width:248px; height:42px; margin-left:43px;" placeholder=""><br>
					Sadržaju: <input v-model="prescriptionCommentInput" type="text" style="width:250px; margin-left:40px;" placeholder=""><br>
					Lekovima: <input v-model="prescriptionMedicamentsInput" type="text" style="width:250px; margin-left:35px; margin-top:0px" placeholder="">

				</template>
				
				<!--
				<select v-if="this.reportsButtonSelected === true" v-model="firstSearchParams" name="firstRow" style="width:160px">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Sobi">Sobi</option>
				</select>
				
				<!--<select v-if="this.prescriptionsButtonSelected === true" v-model="firstSearchParams" name="firstRow" style="width:160px">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Lekovima">Lekovima</option>
				</select>
                			
				<input v-model="publishingDate" v-if="firstSearchParams === 'Datumu'" type="date" format="dd.MM.yyyy." style="width:250px; height:42px">
				<!--<vuejs-datepicker v-if="firstSearchParams === 'Datumu'"></vuejs-datepicker>-->
				
				<!--<input v-else v-model="firstInput" type="text" style="width:250px" placeholder="">-->

				<div class="search-btn">
					<button type="button" @click="simpleSearch()" style="margin-top:3%">Potvrdi</button>
				</div> 
				

		    </div>
     </div>
	 
	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li class="active"><a>Obična</a></li></div><br/>
		    <div><li><a href="#/patientDocumentsAdvancedSearch">Napredna</a></li></div><br/>
	     </ul>
	 </div>
				  
	<template v-if="this.reportsButtonSelected === true">
		<div class="listOfReports">		 
			<div v-for="report in reportsResult" >		 
					<div class="wrapper-reports">
						<div class="report-img">
							<img src="./images/medical-report.png" height="150" width="150" style="margin-left: 13%; margin-top: 17%;">
						</div>
						<div class="report-info">
							<div class="report-text">
								<h1>Izveštaj od doktora: {{report.doctor}}</h1>
								<h3>Soba: {{report.room}}</h3>			
								<p>{{report.publishingDate}}</p>
								<div  style="overflow-y:scroll;height:90px;width:400px;border:1px solid;padding: 5px 5px 10px 5px">
									{{report.comment}}
								</div>
								<div class="reviewReport-btn">
										<button type="button" @click="">Prikaži</button>
								</div>
							</div>
						</div>		
					</div>
			</div>
		</div>
	</template>

	<template v-if="this.prescriptionsButtonSelected === true">
		<div class="listOfReports">		 
			<div v-for="prescription in prescriptionsResult" >		 
				<div class="wrapper-reports">
					<div class="report-img">
						<img src="./images/medical-prescription.png" height="150" width="150" style="margin-left: 11%; margin-top: 21%;">
					</div>
					<div class="report-info">
						<div class="report-text">
							<h1>Recept od doktora: {{prescription.doctor}}</h1></br>		
							<p>{{prescription.publishingDate}}</p>
							<div  style="overflow-y:scroll;height:90px;width:400px;border:1px solid;padding: 5px 5px 10px 5px">
								{{prescription.comment}}
							</div>
							<div class="reviewReport-btn">
									<button type="button" @click="">Prikaži</button>
							</div>
						</div>
					</div>		
				</div>
			</div>
		</div>
	</template>
	
	<!--
	<template v-if="!patientFeedbacks || !patientFeedbacks.length"> 
		<div  class="emptyListOfFeedbacks">
			<h2 >Trenutno nema utisaka pacijenata!</h2>
		</div>
	</template >
	-->
			     	  
	</div>
        
	`
	,
	methods: {
		simpleSearch: function () {
		
			if (this.reportsButtonSelected === true) {
				axios.get('api/medicalExaminationReport/simpleSearchReportsForPatient', {
					params: {
						patientId: 1,
						doctor: this.reportDoctorInput,
						date: this.reportDateInput,
						comment: this.reportCommentInput,
						room: this.reportRoomInput
					},
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
						this.reportsResult = response.data;
				}).catch(error => {
					if (error.response.status === 401 || error.response.status === 403) {
						toast('Nemate pravo pristupa stranici!')
						this.$router.push({ name: 'userLogin' })
					}
				});
			} else if (this.prescriptionsButtonSelected == true) {
				axios.get('api/prescription/simpleSearchPrescriptionForPatient', {
					params: {
						patientId: 1,
						doctor: this.prescriptionDoctorInput,
						date: this.prescriptionDateInput,
						comment: this.prescriptionCommentInput,
						medicaments: this.prescriptionMedicamentsInput
					},
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
					this.prescriptionsResult = response.data;
				}).catch(error => {
					if (error.response.status === 401 || error.response.status === 403) {
						toast('Nemate pravo pristupa stranici!')
						this.$router.push({ name: 'userLogin' })
					}
				});
            }


		},

		reportsSearchButton: function () {
			this.prescriptionsButtonSelected = false;
			this.reportsButtonSelected = true;	
			this.firstSearchParams = 'Doktoru',				
			this.firstInput = '',				
			this.publishingDate = '',
			this.reportsResult = this.reportsForPatient
		},

		prescriptionsSearchButton: function () {
			this.reportsButtonSelected = false;	
			this.prescriptionsButtonSelected = true;
			this.firstSearchParams = 'Doktoru',
			this.firstInput = '',
			this.publishingDate = '',
			this.prescriptionsResult = this.prescriptionsForPatient
		},
		logOut: function () {
			localStorage.removeItem("validToken");
		}
	},
	computed: {

	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');
		axios.get('api/medicalExaminationReport/getForPatient/' + 1, {
			headers: {
				'Authorization': 'Bearer ' + this.userToken
			}
		}).then(response => {
			this.reportsForPatient = response.data;
			this.reportsResult = this.reportsForPatient;
		}).catch(error => {
			if (error.response.status === 401 || error.response.status === 403) {
				toast('Nemate pravo pristupa stranici!')
				this.$router.push({ name: 'userLogin' })
			}
		});
		axios.get('api/prescription/getForPatient/' + 1, {
			headers: {
				'Authorization': 'Bearer ' + this.userToken
			}
		}).then(response => {
			this.prescriptionsForPatient = response.data;
			this.prescriptionsResult = this.prescriptionsForPatient;
		}).catch(error => {
			if (error.response.status === 401 || error.response.status === 403) {
				toast('Nemate pravo pristupa stranici!')
				this.$router.push({ name: 'userLogin' })
			}
		});
	}
});