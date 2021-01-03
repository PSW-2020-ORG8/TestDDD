Vue.component("publishedFeedbacks", {
	data: function () {
		return {
			patientFeedbacks: [],
			userToken: null,
			decodedToken: '',
			userRole: ''
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
				<li v-if="this.userRole === ''"><h1 style="color:white">Dobrodošli u Care-Cure Hospital</h1></li>
	            <li v-if="this.userRole === 'Admin'" class="active"><a href="#/patientsFeedbacks">Utisci pacijenata</a></li>
				<li v-if="this.userRole === 'Admin'"><a href="#/surveyResults">Rezultati anketa</a></li>
				<li v-if="this.userRole === 'Admin'"><a href="#/blockMaliciousPatients">Zlonamerni korisnici</a></li>
				<li v-if="this.userRole === 'Patient'"><a href="#/patientAppointments">Pregledi</a></li>
                <li v-if="this.userRole === 'Patient'" class="active"><a href="#/">Utisci</a></li>
                <li v-if="this.userRole === 'Patient'"><a href="#/patientMainPage">Početna</a></li>
                <li v-if="this.userRole === 'Patient'"><a href="#/medicalRecordReview">Moj karton</a></li>
                <li v-if="this.userRole === 'Patient'"><a href="#/patientDocumentsSimpleSearch">Dokumenti</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="images/menuIcon.png" />
	        	<img id="userIcon" src="images/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a v-if="this.userRole === ''" href="#/patientRegistration">Registruj se</a>
	            <a v-if="this.userRole === ''" href="#/userLogin">Prijavi se</a>
				<a v-if="this.userRole !== ''" href="#/userLogin" @click="logOut()">Odjavi se</a>
		    </div>
	    </div>
	 </div>
	 
	 <div class="verticalLine" v-if="this.userRole !== ''"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
		    <div><li v-if="this.userRole === 'Admin'"><a href="#/patientsFeedbacks">Svi utisci</a></li></div><br v-if="this.userRole === 'Admin'"/>
			<div><li v-if="this.userRole === 'Admin'" class="active"><a href="#/">Objavljeni utisci</a></li></div><br v-if="this.userRole === 'Admin'"/>
			<div><li v-if="this.userRole === 'Patient'" class="active"><a href="#/">Objavljeni utisci</a></li></div><br v-if="this.userRole === 'Patient'"/>
			<div><li v-if="this.userRole === 'Patient'"><a href="#/postFeedback">Ostavite utisak</a></li></div><br v-if="this.userRole === 'Patient'"/>
	     </ul>
	 </div>	 

	<!--
	 <div class="titleForPublishedFeedbackPreview">
		 <h1>Utisci pacijenata</h1>
	 </div> 
	-->	 

	 <div class="listOfFeedbacks" v-if="this.userRole !== ''">		 
	 <div v-for="pf in patientFeedbacks">	 
		<div class="wrapper">
		    <div class="feedback-img">
		        <img src="./images/satisfaction.png" height="150" width="150" style="margin-left: 18%; margin-top: 21%;">
		    </div>
		    <div class="feedback-info">
		        <div class="feedback-text">
		            <h1 v-if="pf.isAnonymous === true">Anonimni pacijent</h1>
					<h1 v-else >{{pf.patient}}</h1>
		            <p>{{pf.publishingDate}}</p>
					<h3></h3>
					<div  style="overflow-y:scroll;height:100px;width:460px;border:1px solid;padding: 10px 10px 15px 10px;">
						{{pf.text}}
				    </div>
		        </div>
			</div>
	     </div>	
	 </div>
	 </div>

	<div class="listOfFeedbacks" v-if="this.userRole === ''">		 
		 <div v-for="pf in patientFeedbacks">	 
			<div class="wrapper" style="margin-left:27.3%">
				<div class="feedback-img">
					<img src="./images/satisfaction.png" height="150" width="150" style="margin-left: 18%; margin-top: 21%;">
				</div>
				<div class="feedback-info">
					<div class="feedback-text">
						<h1 v-if="pf.isAnonymous === true">Anonimni pacijent</h1>
						<h1 v-else >{{pf.patient}}</h1>
						<p>{{pf.publishingDate}}</p>
						<h3></h3>
						<div  style="overflow-y:scroll;height:100px;width:460px;border:1px solid;padding: 10px 10px 15px 10px;">
							{{pf.text}}
						</div>
					</div>
				</div>
			</div>	
		</div>
	 </div>

			     	  
	</div>
        
	`
	,
	methods: {
		logOut: function () {
			localStorage.removeItem("validToken");
		}
	},
	mounted() {
		this.userRole = '';
		this.userToken = localStorage.getItem('validToken');

		axios.get('api/patientFeedback/getPublishedFeedbacks').then(response => {
			this.patientFeedbacks = response.data;
		});

		if (this.userToken !== null) {
			var base64Url = this.userToken.split('.')[1];
			var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
			var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
				return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
			}).join(''));

			this.decodedToken = JSON.parse(jsonPayload);
			this.userRole = this.decodedToken.role;
        }
		
	}

});