Vue.component("blockMaliciousPatients", {
	data: function () {
		return {
			maliciousPatients: [],
			userToken: null
		}
	},
	template: `
	<div>
	
	<div class="boundary-for-scroll-block-malicious-patients">
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
				<li><a href="#/patientsFeedbacks">Utisci pacijenata</a></li>
				<li><a href="#/surveyResults">Rezultati anketa</a></li>
				<li class="active"><a href="#/blockMaliciousPatients">Zlonamerni korisnici</a></li>
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
	
	<div class="block-malicious-patients">	
		<h3 class = "block-malicious-patients-title">Spisak potencijalno zlonamernih korisnika:</h3> 
		<table class="table-block-malicious-patients">
			<tr>
				<th>Korisničko ime</th>
				<th>Ime</th>
				<th>Prezime</th>
				<th style="max-width:90px;">Broj otkazivanja na mesečnom nivou</th>
				<th></th>
			</tr>
			<tr v-for = "maliciousPatient in maliciousPatients">
				<td>{{maliciousPatient.username}}</td>
				<td>{{maliciousPatient.name}}</td>
				<td>{{maliciousPatient.surname}}</td>
				<td>{{maliciousPatient.numberOfCancelledAppointents}}</td>
				<td class="patient-for-blocking" v-if="maliciousPatient.blocked === false">
				<button class="block-malicious-patient-btn" style="width: 130px; height: 40px; font-size: 16px;" type="button" @click="blockUser(maliciousPatient.id)">Blokiraj</button>
				</td>
				<td v-if="maliciousPatient.blocked === true" style="color: red">
					Pacijent je blokiran
				</td>
			</tr>			
		</table> 
	</div>
	     
	</div>	  
	</div>
        
	`
	,
	methods: {
		blockUser : function(patientId) {
			if (confirm('Da li ste sigurni da želite da blokirate pacijenta?') == true) {
				axios.put('api/patient/blockMaliciousPatient/' + patientId, {
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
					axios.get('api/patient/getMaliciousPatients', {
						headers: {
							'Authorization': 'Bearer ' + this.userToken
						}
					}).then(response => {
							this.maliciousPatients = response.data;
					}).catch(error => {
						if (error.response.status === 401 || error.response.status === 403) {
							toast('Nemate pravo pristupa stranici!')
							this.$router.push({ name: 'userLogin' })
						}
					});
				}).catch(error => {
					if (error.response.status === 401 || error.response.status === 403) {
						toast('Nemate pravo pristupa stranici!')
						this.$router.push({ name: 'userLogin' })
					}
				});
                toast('Uspešno ste blokirali pacijenta!')
            }
		},
		logOut: function () {
			localStorage.removeItem("validToken");
		}

	},
	computed: {

	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');
		axios.get('api/patient/getMaliciousPatients', {
			headers: {
				'Authorization': 'Bearer ' + this.userToken
			}
		}).then(response => {
			this.maliciousPatients = response.data;
		}).catch(error => {
			if (error.response.status === 401 || error.response.status === 403) {
				toast('Nemate pravo pristupa stranici!')
				this.$router.push({ name: 'userLogin' })
			}
		});
	}

});