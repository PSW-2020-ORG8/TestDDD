Vue.component("surveyResults", {
	data: function () {
		return {
			surveyResults: [],
			doctorQuestionsAverageGrade: 0,
			staffQuestionsAverageGrade: 0,
			hospitalQuestionsAverageGrade: 0,
			userToken: null
		}
	},
	template: `
	<div>
	
	<div class="boundaryForScrollSurvey">
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
				<li class="active"><a href="#/surveyResults">Rezultati anketa</a></li>
				<li><a href="#/blockMaliciousPatients">Zlonamerni korisnici</a></li>
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
		
	<div class="survey-vertical-line"></div>
	
	<div class="sideComponents">      
    <ul class="ulForSideComponents">
       <div><li style="margin-left : 30px" class="active"><a href="#/surveyResults">Opšti rezultati</a></li></div><br/>
       <div><li style="margin-left : 30px"><a href="#/doctorSurveyResults">Rezultati za doktore</a></li></div><br/>
    </ul>
    </div>  

	
	<div class="survey-questions" style="margin-left:20%">	
		<h3 class = "doctor-qestions-title">Pitanja o doktoru kod kog je izvršen pregled:</h3> 
		<table class="questions-about-doctor">
			<tr>
			<th style="min-width:430px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			<th style="min-width:90px;">Prosek</th>
			</tr>
			<tr>
            <td>Ljubaznost doktora prema pacijentu</td>
            <template v-for="grade in this.surveyResults[0].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[0].averageGrade}}</td>
			</tr>
			<tr>
			<td>Posvećenost doktora pacijentu</td>
			<template v-for="grade in this.surveyResults[1].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[1].averageGrade}}</td>
			</tr>
			<tr>
			<td>Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja</td>
			<template v-for="grade in this.surveyResults[2].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[2].averageGrade}}</td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td>{{this.doctorQuestionsAverageGrade.toFixed(2)}}</td>
			</tr>
		</table> 
		<h3 class = "medicalstaff-qestions-title">Pitanja o medicinskom osoblju bolnice:</h3> 
		<table class="questions-about-medicalstaff">
			<tr>
			<th style="min-width:430px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			<th style="min-width:90px;">Prosek</th>
			</tr>
			<tr>
			<td>Ljubaznost medicinskog osoblja prema pacijentu</td>
			<template v-for="grade in this.surveyResults[3].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[3].averageGrade}}</td>
			</tr>
			<tr>
			<td>Posvećenost medicinskog osoblja pacijentu</td>
			<template v-for="grade in this.surveyResults[4].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[4].averageGrade}}</td>
			</tr>
			<tr>
			<td>Profesionalizam u obavljanju svoji duznosti medicinskog osoblja</td>
			<template v-for="grade in this.surveyResults[5].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[5].averageGrade}}</td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td>{{this.staffQuestionsAverageGrade.toFixed(2)}}</td>
			</tr>
		</table> 
		<h3 class = "hospital-qestions-title">Pitanja o radu bolnice:</h3> 
		<table class="questions-about-hospital">
			<tr>
			<th style="min-width:430px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			<th style="min-width:90px;">Prosek</th>
			</tr>
			<tr>
			<td>Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici</td>
			<template v-for="grade in this.surveyResults[6].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[6].averageGrade}}</td>
			</tr>
			<tr>
			<td>Higijena unutar bolnice</td>
			<template v-for="grade in this.surveyResults[7].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[7].averageGrade}}</td>
			</tr>
			<tr>
			<td>Opremljenost bolnice</td>
			<template v-for="grade in this.surveyResults[8].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[8].averageGrade}}</td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td>{{this.hospitalQuestionsAverageGrade.toFixed(2)}}</td>
			</tr>
		</table> 	

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
	computed: {

	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');

		axios.get('api/survey/getSurveyResults', {
			headers: {
			'Authorization': 'Bearer ' + this.userToken }
		}).then(response => {
			this.surveyResults = response.data;
			this.doctorQuestionsAverageGrade = (this.surveyResults[0].averageGrade + this.surveyResults[1].averageGrade + this.surveyResults[2].averageGrade) / 3;
			this.staffQuestionsAverageGrade = (this.surveyResults[3].averageGrade + this.surveyResults[4].averageGrade + this.surveyResults[5].averageGrade) / 3;
			this.hospitalQuestionsAverageGrade = (this.surveyResults[6].averageGrade + this.surveyResults[7].averageGrade + this.surveyResults[8].averageGrade) / 3;
		}).catch(error => {
			if (error.response.status === 401 || error.response.status === 403) {
				toast('Nemate pravo pristupa stranici!')
				this.$router.push({ name: 'userLogin' })
			}
		});

	}

});