Vue.component("patientDocumentsAdvancedSearch", {
	data: function () {
		return {
			reportsForPatient: [],
			prescriptionsForPatient : [],
			firstSearchParams: 'Doktoru',
			secondSearchParams: 'Doktoru',
			thirdSearchParams: 'Doktoru',
			fourthSearchParams: 'Doktoru',
			firstLogicOperators: 'I',
			secondLogicOperators: 'I',
			thirdLogicOperators: 'I',
			fourthLogicOperators: 'I',
			count: 0,
			firstInput: '',
			secondInput: '',
			thirdInput: '',
			fourthInput: '',
			firstPublishingDate: '',
			secondPublishingDate: '',
			thirdPublishingDate: '',
			fourthPublishingDate: '',
			reportsButtonSelected : true,
			prescriptionsButtonSelected : false,
			reportsResult: [],
			prescriptionsResult: [],
			paramInputDict: {},
			logicOperatorsList: [],
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

	<div class="filterReports">
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

                <select v-if="this.reportsButtonSelected === true" v-model="firstSearchParams" name="firstRow">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Sobi">Sobi</option>
				</select>
				<select v-if="this.prescriptionsButtonSelected === true" v-model="firstSearchParams" name="firstRow">
					<option value="Doktoru" selected>Doktoru</option>
					<option value="Datumu">Datumu</option>
					<option value="Sadržaju">Sadržaju</option>
					<option value="Lekovima">Lekovima</option>
				</select>

				<input v-if="firstSearchParams === 'Datumu'" v-model="firstPublishingDate" type="date" style="width:150px;height:42px">
				<input v-else v-model="firstInput" type="text" style="width:150px" placeholder="">

				<select v-model="firstLogicOperators" v-if="this.count !== 0" style="width:90px" name="firstRow">
					<option value="I" selected>I</option>
					<option value="ILI">ILI</option>
				</select>

				<div v-if="this.count === 0" class="add-param-btn">
                	<button type="button" @click="add">+</button>
				</div>
				<div v-if="this.count >= 1" class="add-param-btn">
                	<button type="button" @click="dec">-</button>
				</div>
									
				<div v-if="this.count >= 1" class="second-row" name="secondRow">
					<select v-if="this.reportsButtonSelected === true" v-model="secondSearchParams" name="firstRow">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sadržaju">Sadržaju</option>
						<option value="Sobi">Sobi</option>
					</select>
					<select v-if="this.prescriptionsButtonSelected === true" v-model="secondSearchParams" name="firstRow">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sadržaju">Sadržaju</option>
						<option value="Lekovima">Lekovima</option>
					</select>

					<input v-if="secondSearchParams === 'Datumu'" v-model="secondPublishingDate" type="date" style="width:150px;height:42px">
					<input v-else v-model="secondInput" type="text" style="width:150px" placeholder="">

					<select v-model="secondLogicOperators" v-if="this.count !== 1" style="width:90px" name="secondRow">
						<option value="I" selected>I</option>
						<option value="ILI">ILI</option>
					</select>

					<div v-if="this.count == 1" class="add-param-btn">
						<button type="button" @click="add">+</button>
					</div>
					<div v-if="this.count >= 2" class="add-param-btn">
                		<button type="button" @click="dec">-</button>
					</div>
				</div>

				<div v-if="this.count >= 2" class="third-row">
					<select v-if="this.reportsButtonSelected === true" v-model="thirdSearchParams" name="firstRow">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sadržaju">Sadržaju</option>
						<option value="Sobi">Sobi</option>
					</select>
					<select v-if="this.prescriptionsButtonSelected === true" v-model="thirdSearchParams" name="firstRow">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sadržaju">Sadržaju</option>
						<option value="Lekovima">Lekovima</option>
					</select>

					<input v-if="thirdSearchParams === 'Datumu'" v-model="thirdPublishingDate" type="date" style="width:150px;height:42px">
					<input v-else v-model="thirdInput" type="text" style="width:150px" placeholder="">

					<select v-model="thirdLogicOperators" v-if="this.count !== 2" style="width:90px">
						<option value="I" selected>I</option>
						<option value="ILI">ILI</option>
					</select>

					<div v-if="this.count == 2" class="add-param-btn">
						<button type="button" @click="add">+</button>
					</div>
					<div v-if="this.count >= 3" class="add-param-btn">
                		<button type="button" @click="dec">-</button>
					</div>
				</div>

				<div v-if="this.count >= 3" class="fourth-row">
					<select v-if="this.reportsButtonSelected === true" v-model="fourthSearchParams" name="firstRow">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sadržaju">Sadržaju</option>
						<option value="Sobi">Sobi</option>
					</select>
					<select v-if="this.prescriptionsButtonSelected === true" v-model="fourthSearchParams" name="firstRow">
						<option value="Doktoru" selected>Doktoru</option>
						<option value="Datumu">Datumu</option>
						<option value="Sadržaju">Sadržaju</option>
						<option value="Lekovima">Lekovima</option>
					</select>

					<input v-if="fourthSearchParams === 'Datumu'" v-model="fourthPublishingDate" type="date" style="width:150px;height:42px">
					<input v-else v-model="fourthInput" type="text" style="width:150px" placeholder="">
				
					<div v-if="this.count == 3" class="add-param-btn">
						<button type="button" @click="dec">-</button>
					</div>
				</div>

				<div class="search-btn">
					<button type="button" @click="advancedSearch()">Potvrdi</button>
				</div>

		    </div>
     </div>
	 
	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li><a href="#/patientDocumentsSimpleSearch">Obična</a></li></div><br/>
		    <div><li class="active"><a href="#/patientDocumentsAdvancedSearch">Napredna</a></li></div><br/>
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
		advancedSearch: function () {
			this.paramInputDict = {}
			this.logicOperatorsList = []

			if(this.count === 0) {
				if(this.firstSearchParams === 'Datumu') {
					this.paramInputDict[this.firstSearchParams] = this.firstPublishingDate
				} else if(this.firstSearchParams === 'Doktoru') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
				} else if(this.firstSearchParams === 'Sadržaju') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
				} else if(this.firstSearchParams === 'Sobi') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
				} else if(this.firstSearchParams === 'Lekovima') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
				}	
			} else {
				if(this.firstSearchParams === 'Datumu') {
					this.paramInputDict[this.firstSearchParams] = this.firstPublishingDate
					this.logicOperatorsList.push(this.firstLogicOperators)
				} else if(this.firstSearchParams === 'Doktoru') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
					this.logicOperatorsList.push(this.firstLogicOperators)
				} else if(this.firstSearchParams === 'Sadržaju') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
					this.logicOperatorsList.push(this.firstLogicOperators)
				} else if(this.firstSearchParams === 'Sobi') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
					this.logicOperatorsList.push(this.firstLogicOperators)
				} else if(this.firstSearchParams === 'Lekovima') {
					this.paramInputDict[this.firstSearchParams] = this.firstInput 
					this.logicOperatorsList.push(this.firstLogicOperators)
				}	
			}			

			if (this.count >= 1) {
				if (this.firstSearchParams === this.secondSearchParams) {
					toast("Ne smete da odaberete više puta isti parametar za pretragu")
				} else {
					if (this.secondSearchParams === 'Datumu') {
						this.paramInputDict[this.secondSearchParams] = this.secondPublishingDate
						this.logicOperatorsList.push(this.secondLogicOperators)
					} else if (this.secondSearchParams === 'Doktoru') {
						this.paramInputDict[this.secondSearchParams] = this.secondInput
						this.logicOperatorsList.push(this.secondLogicOperators)
					} else if (this.secondSearchParams === 'Sadržaju') {
						this.paramInputDict[this.secondSearchParams] = this.secondInput
						this.logicOperatorsList.push(this.secondLogicOperators)
					} else if (this.secondSearchParams === 'Sobi') {
						this.paramInputDict[this.secondSearchParams] = this.secondInput
						this.logicOperatorsList.push(this.secondLogicOperators)
					} else if (this.secondSearchParams === 'Lekovima') {
						this.paramInputDict[this.secondSearchParams] = this.secondInput
						this.logicOperatorsList.push(this.secondLogicOperators)
					} 	
                }						
			}
			
			if (this.count >= 2) {
				if (this.thirdSearchParams === this.firstSearchParams || this.thirdSearchParams === this.secondSearchParams) {
					toast("Ne smete da odaberete vise puta isti parametar za pretragu")
				} else {
					if (this.thirdSearchParams === 'Datumu') {
						this.paramInputDict[this.thirdSearchParams] = this.thirdPublishingDate
						this.logicOperatorsList.push(this.thirdLogicOperators)
					} else if (this.thirdSearchParams === 'Doktoru') {
						this.paramInputDict[this.thirdSearchParams] = this.thirdInput
						this.logicOperatorsList.push(this.thirdLogicOperators)
					} else if (this.thirdSearchParams === 'Sadržaju') {
						this.paramInputDict[this.thirdSearchParams] = this.thirdInput
						this.logicOperatorsList.push(this.thirdLogicOperators)
					} else if (this.thirdSearchParams === 'Sobi') {
						this.paramInputDict[this.thirdSearchParams] = this.thirdInput
						this.logicOperatorsList.push(this.thirdLogicOperators)
					} else if (this.thirdSearchParams === 'Lekovima') {
						this.paramInputDict[this.thirdSearchParams] = this.thirdInput
						this.logicOperatorsList.push(this.thirdLogicOperators)
					}
				}
			}
			
			if (this.count >= 3) {
				if (this.fourthSearchParams === this.firstSearchParams || this.fourthSearchParams === this.secondSearchParams || this.fourthSearchParams === this.thirdSearchParams) {
					toast("Ne smete da odaberete vise puta isti parametar za pretragu")
				} else {
					if (this.fourthSearchParams === 'Datumu') {
						this.paramInputDict[this.fourthSearchParams] = this.fourthPublishingDate
					} else if (this.fourthSearchParams === 'Doktoru') {
						this.paramInputDict[this.fourthSearchParams] = this.fourthInput
					} else if (this.fourthSearchParams === 'Sadržaju') {
						this.paramInputDict[this.fourthSearchParams] = this.fourthInput
					} else if (this.fourthSearchParams === 'Sobi') {
						this.paramInputDict[this.fourthSearchParams] = this.fourthInput
					} else if (this.fourthSearchParams === 'Lekovima') {
						this.paramInputDict[this.fourthSearchParams] = this.fourthInput
					}
				}
			}
				
			if (this.reportsButtonSelected === true) {
				axios.post('api/medicalExaminationReport/advancedSearchReportsForPatient', {
					patientId: 1,
					searchParams: this.paramInputDict,
					logicOperators: this.logicOperatorsList
				}, {
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
			} else if (this.prescriptionsButtonSelected === true) {
				axios.post('api/prescription/advancedSearchPrescriptionsForPatient', {
					patientId: 1,
					searchParams: this.paramInputDict,
					logicOperators: this.logicOperatorsList
				}, {
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

		add: function () {
			this.count += 1		
		},

		dec: function () {
			this.count -= 1
			if(this.count === 2){
				this.fourthSearchParams = 'Doktoru'
				this.fourthInput = ''
				this.fourthPublishingDate = ''
			} else if(this.count === 1) {
				this.thirdSearchParams = 'Doktoru'
				this.thirdLogicOperators = 'I'
				this.thirdInput = ''
				this.thirdPublishingDate = ''
			} else if(this.count === 0) {
				this.secondSearchParams = 'Doktoru'
				this.secondLogicOperators = 'I'
				this.secondInput = ''
				this.secondPublishingDate = ''
			}
		},

		reportsSearchButton: function () {
			this.prescriptionsButtonSelected = false;
			this.reportsButtonSelected = true;	
			this.count = 0,
			this.firstSearchParams = 'Doktoru',
			this.secondSearchParams = 'Doktoru',
			this.thirdSearchParams = 'Doktoru',
			this.fourthSearchParams = 'Doktoru',
			this.firstLogicOperators = 'I',
			this.secondLogicOperators = 'I',
			this.thirdLogicOperators = 'I',
			this.fourthLogicOperators = 'I',
			this.firstInput = '',
			this.secondInput = '',
			this.thirdInput = '',
			this.fourthInput = '',
			this.firstPublishingDate = '',
			this.secondPublishingDate = '',
			this.thirdPublishingDate = '',
			this.fourthPublishingDate = '',
			this.paramInputDict = {},
			this.logicOperatorsList = [],
			this.reportsResult = this.reportsForPatient
		},

		prescriptionsSearchButton: function () {
			this.reportsButtonSelected = false;	
			this.prescriptionsButtonSelected = true;
			this.count = 0,
			this.firstSearchParams = 'Doktoru',
			this.secondSearchParams = 'Doktoru',
			this.thirdSearchParams = 'Doktoru',
			this.fourthSearchParams = 'Doktoru',
			this.firstLogicOperators = 'I',
			this.secondLogicOperators = 'I',
			this.thirdLogicOperators = 'I',
			this.fourthLogicOperators = 'I',
			this.firstInput = '',
			this.secondInput = '',
			this.thirdInput = '',
			this.fourthInput = '',
			this.firstPublishingDate = '',
			this.secondPublishingDate = '',
			this.thirdPublishingDate = '',
			this.fourthPublishingDate = '',
			this.paramInputDict = {},
			this.logicOperatorsList = [],
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