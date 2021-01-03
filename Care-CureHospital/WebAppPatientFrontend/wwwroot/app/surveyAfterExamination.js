Vue.component("surveyAfterExamination", {
	data: function () {
		return {
			listOfAnswers: [],
			commentSurvey: '',

			textOfQuestion1: '',
			gradeOfQuestion1: null,
			answer1 : 'good',

			textOfQuestion2: '',
			gradeOfQuestion2: null,
			answer2: 'good',

			textOfQuestion3: '',
			gradeOfQuestion3: null,
			answer3: 'good',

			textOfQuestion4: '',
			gradeOfQuestion4: null,
			answer4: 'good',

			textOfQuestion5: '',
			gradeOfQuestion5: null,
			answer5: 'good',

			textOfQuestion6: '',
			gradeOfQuestion6: null,
			answer6: 'good',

			textOfQuestion7: '',
			gradeOfQuestion7: null,
			answer7: 'good',

			textOfQuestion8: '',
			gradeOfQuestion8: null,
			answer8: 'good',

			textOfQuestion9: '',
			gradeOfQuestion9: null,
			answer9: 'good',

			medicalExaminationId: null,
			appointmentId: null,
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
				<li><a href="#/patientAppointments">Nazad na preglede</a></li>
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
	
	<div class="survey-questions">	
		<h3 class = "doctor-qestions-title">Pitanja o doktoru kod kog je izvršen pregled:</h3> 
		<table class="questions-about-doctor">
			<tr>
				<th style="min-width:530px;">Pitanja</th>
				<th style="min-width:90px;">Vrlo loše</th>
				<th style="min-width:90px;">Loše</th>
				<th style="min-width:90px;">Dobro</th>
				<th style="min-width:90px;">Vrlo dobro</th>
				<th style="min-width:90px;">Odlično</th>
			</tr>
			<tr>
				<td v-model="textOfQuestion1">Ljubaznost doktora prema pacijentu</td>
				<td><input v-model="answer1" type="radio" id="poor" name="gradeOfQuestion1" value="poor"></td>
				<td><input v-model="answer1" type="radio" id="fair" name="gradeOfQuestion1" value="fair"></td>
				<td><input v-model="answer1" type="radio" id="good" name="gradeOfQuestion1" value="good"></td>
				<td><input v-model="answer1" type="radio" id="veryGood" name="gradeOfQuestion1" value="veryGood"></td>
				<td><input v-model="answer1" type="radio" id="excellent" name="gradeOfQuestion1" value="excellent"></td>
			</tr>
			<tr>
				<td v-model="textOfQuestion2">Posvećenost doktora pacijentu</td>
				<td><input v-model="answer2" type="radio" id="poor" name="gradeOfQuestion2" value="poor"></td>
				<td><input v-model="answer2" type="radio" id="fair" name="gradeOfQuestion2" value="fair"></td>
				<td><input v-model="answer2" type="radio" id="good" name="gradeOfQuestion2" value="good"></td>
				<td><input v-model="answer2" type="radio" id="veryGood" name="gradeOfQuestion2" value="veryGood"></td>
				<td><input v-model="answer2" type="radio" id="excellent" name="gradeOfQuestion2" value="excellent"></td>
			</tr>
			<tr>
				<td v-model="textOfQuestion3">Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja</td>
				<td><input v-model="answer3" type="radio" id="poor" name="gradeOfQuestion3" value="poor"></td>
				<td><input v-model="answer3" type="radio" id="fair" name="gradeOfQuestion3" value="fair"></td>
				<td><input v-model="answer3" type="radio" id="good" name="gradeOfQuestion3" value="good"></td>
				<td><input v-model="answer3" type="radio" id="veryGood" name="gradeOfQuestion3" value="veryGood"></td>
				<td><input v-model="answer3" type="radio" id="excellent" name="gradeOfQuestion3" value="excellent"></td>
			</tr>
		</table> 
		<h3 class = "medicalstaff-qestions-title">Pitanja o medicinskom osoblju bolnice:</h3> 
		<table class="questions-about-medicalstaff">
			<tr>
				<th style="min-width:530px;">Pitanja</th>
				<th style="min-width:90px;">Vrlo loše</th>
				<th style="min-width:90px;">Loše</th>
				<th style="min-width:90px;">Dobro</th>
				<th style="min-width:90px;">Vrlo dobro</th>
				<th style="min-width:90px;">Odlično</th>
			</tr>
			<tr>
				<td v-model="textOfQuestion4">Ljubaznost medicinskog osoblja prema pacijentu</td>
				<td><input v-model="answer4" type="radio" id="poor" name="gradeOfQuestion4" value="poor"></td>
				<td><input v-model="answer4" type="radio" id="fair" name="gradeOfQuestion4" value="fair"></td>
				<td><input v-model="answer4" type="radio" id="good" name="gradeOfQuestion4" value="good"></td>
				<td><input v-model="answer4" type="radio" id="veryGood" name="gradeOfQuestion4" value="veryGood"></td>
				<td><input v-model="answer4" type="radio" id="excellent" name="gradeOfQuestion4" value="excellent"></td>
			</tr>
			<tr>
				<td v-model="textOfQuestion5">Posvećenost medicinskog osoblja pacijentu</td>
				<td><input v-model="answer5" type="radio" id="poor" name="gradeOfQuestion5" value="poor"></td>
				<td><input v-model="answer5" type="radio" id="fair" name="gradeOfQuestion5" value="fair"></td>
				<td><input v-model="answer5" type="radio" id="good" name="gradeOfQuestion5" value="good"></td>
				<td><input v-model="answer5" type="radio" id="veryGood" name="gradeOfQuestion5" value="veryGood"></td>
				<td><input v-model="answer5" type="radio" id="excellent" name="gradeOfQuestion5" value="excellent"></td>
			</tr>
			<tr>
				<td v-model="textOfQuestion6">Profesionalizam u obavljanju svoji duznosti medicinskog osoblja</td>
				<td><input v-model="answer6" type="radio" id="poor" name="gradeOfQuestion6" value="poor"></td>
				<td><input v-model="answer6" type="radio" id="fair" name="gradeOfQuestion6" value="fair"></td>
				<td><input v-model="answer6" type="radio" id="good" name="gradeOfQuestion6" value="good"></td>
				<td><input v-model="answer6" type="radio" id="veryGood" name="gradeOfQuestion6" value="veryGood"></td>
				<td><input v-model="answer6" type="radio" id="excellent" name="gradeOfQuestion6" value="excellent"></td>
			</tr>
		</table> 
		<h3 class = "hospital-qestions-title">Pitanja o radu bolnice:</h3> 
		<table class="questions-about-hospital">
			<tr>
				<th style="min-width:530px;">Pitanja</th>
				<th style="min-width:90px;">Vrlo loše</th>
				<th style="min-width:90px;">Loše</th>
				<th style="min-width:90px;">Dobro</th>
				<th style="min-width:90px;">Vrlo dobro</th>
				<th style="min-width:90px;">Odlično</th>
			</tr>
			<tr>
				<td v-model="textOfQuestion7">Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici</td>
				<td><input v-model="answer7" type="radio" id="poor" name="gradeOfQuestion7" value="poor"></td>
				<td><input v-model="answer7" type="radio" id="fair" name="gradeOfQuestion7" value="fair"></td>
				<td><input v-model="answer7" type="radio" id="good" name="gradeOfQuestion7" value="good"></td>
				<td><input v-model="answer7" type="radio" id="veryGood" name="gradeOfQuestion7" value="veryGood"></td>
				<td><input v-model="answer7" type="radio" id="excellent" name="gradeOfQuestion7" value="excellent"></td>
			</tr>
			<tr>
				<td v-model="textOfQuestion8">Higijena unutar bolnice</td>
				<td><input v-model="answer8" type="radio" id="poor" name="gradeOfQuestion8" value="poor"></td>
				<td><input v-model="answer8" type="radio" id="fair" name="gradeOfQuestion8" value="fair"></td>
				<td><input v-model="answer8" type="radio" id="good" name="gradeOfQuestion8" value="good"></td>
				<td><input v-model="answer8" type="radio" id="veryGood" name="gradeOfQuestion8" value="veryGood"></td>
				<td><input v-model="answer8" type="radio" id="excellent" name="gradeOfQuestion8" value="excellent"></td>
			</tr>
			<tr>
				<td v-model="textOfQuestion9">Opremljenost bolnice</td>
				<td><input v-model="answer9" type="radio" id="poor" name="gradeOfQuestion9" value="poor"></td>
				<td><input v-model="answer9" type="radio" id="fair" name="gradeOfQuestion9" value="fair"></td>
				<td><input v-model="answer9" type="radio" id="good" name="gradeOfQuestion9" value="good"></td>
				<td><input v-model="answer9" type="radio" id="veryGood" name="gradeOfQuestion9" value="veryGood"></td>
				<td><input v-model="answer9" type="radio" id="excellent" name="gradeOfQuestion9" value="excellent"></td>
			</tr>
		</table> 
		<h3 class = "survey-comment-title">Komentar:</h3> 
		<textarea v-model="commentSurvey" class = "survey-comment" placeholder="Prostor za dodatni komentar..." rows="9" cols="92" style="resize: none;"></textarea>

		<div class="survey-comment-btn">
			<button type="button" @click="postSurvey">Pošalji</button>
		</div>

	</div>     
	</div>	  
	</div>
        
	`
	,
	methods: {
		postSurvey: function () {

			this.listOfAnswers = []

			if (this.answer1 == "poor") {
				this.gradeOfQuestion1 = 0;
			} else if (this.answer1 == "fair"){
				this.gradeOfQuestion1 = 1;
			} else if (this.answer1 == "good") {
				this.gradeOfQuestion1 = 2;
			} else if (this.answer1 == "veryGood") {
				this.gradeOfQuestion1 = 3;
			} else if (this.answer1 == "excellent") {
				this.gradeOfQuestion1 = 4;
			}

			var answerOfQuestion1={
				grade: this.gradeOfQuestion1,
				questionId: 1
			}

			if (this.answer2 == "poor") {
				this.gradeOfQuestion2 = 0;
			} else if (this.answer2 == "fair") {
				this.gradeOfQuestion2 = 1;
			} else if (this.answer2 == "good") {
				this.gradeOfQuestion2 = 2;
			} else if (this.answer2 == "veryGood") {
				this.gradeOfQuestion2 = 3;
			} else if (this.answer2 == "excellent") {
				this.gradeOfQuestion2 = 4;
			}

			var answerOfQuestion2 = {
				grade: this.gradeOfQuestion2,
				questionId: 2
			}

			if (this.answer3 == "poor") {
				this.gradeOfQuestion3 = 0;
			} else if (this.answer3 == "fair") {
				this.gradeOfQuestion3 = 1;
			} else if (this.answer3 == "good") {
				this.gradeOfQuestion3 = 2;
			} else if (this.answer3 == "veryGood") {
				this.gradeOfQuestion3 = 3;
			} else if (this.answer3 == "excellent") {
				this.gradeOfQuestion3 = 4;
			}

			var answerOfQuestion3 = {
				grade: this.gradeOfQuestion3,
				questionId: 3
			}

			if (this.answer4 == "poor") {
				this.gradeOfQuestion4 = 0;
			} else if (this.answer4 == "fair") {
				this.gradeOfQuestion4 = 1;
			} else if (this.answer4 == "good") {
				this.gradeOfQuestion4 = 2;
			} else if (this.answer4 == "veryGood") {
				this.gradeOfQuestion4 = 3;
			} else if (this.answer4 == "excellent") {
				this.gradeOfQuestion4 = 4;
			}

			var answerOfQuestion4 = {
				grade: this.gradeOfQuestion4,
				questionId: 4
			}

			if (this.answer5 == "poor") {
				this.gradeOfQuestion5 = 0;
			} else if (this.answer5 == "fair") {
				this.gradeOfQuestion5 = 1;
			} else if (this.answer5 == "good") {
				this.gradeOfQuestion5 = 2;
			} else if (this.answer5 == "veryGood") {
				this.gradeOfQuestion5 = 3;
			} else if (this.answer5 == "excellent") {
				this.gradeOfQuestion5 = 4;
			}

			var answerOfQuestion5 = {
				grade: this.gradeOfQuestion5,
				questionId: 5
			}

			if (this.answer6 == "poor") {
				this.gradeOfQuestion6 = 0;
			} else if (this.answer6 == "fair") {
				this.gradeOfQuestion6 = 1;
			} else if (this.answer6 == "good") {
				this.gradeOfQuestion6 = 2;
			} else if (this.answer6 == "veryGood") {
				this.gradeOfQuestion6 = 3;
			} else if (this.answer6 == "excellent") {
				this.gradeOfQuestion6 = 4;
			}

			var answerOfQuestion6 = {
				grade: this.gradeOfQuestion6,
				questionId: 6
			}

			if (this.answer7 == "poor") {
				this.gradeOfQuestion7 = 0;
			} else if (this.answer7 == "fair") {
				this.gradeOfQuestion7 = 1;
			} else if (this.answer7 == "good") {
				this.gradeOfQuestion7 = 2;
			} else if (this.answer7 == "veryGood") {
				this.gradeOfQuestion7 = 3;
			} else if (this.answer7 == "excellent") {
				this.gradeOfQuestion7 = 4;
			}

			var answerOfQuestion7 = {
				grade: this.gradeOfQuestion7,
				questionId: 7
			}

			if (this.answer8 == "poor") {
				this.gradeOfQuestion8 = 0;
			} else if (this.answer8 == "fair") {
				this.gradeOfQuestion8 = 1;
			} else if (this.answer8 == "good") {
				this.gradeOfQuestion8 = 2;
			} else if (this.answer8 == "veryGood") {
				this.gradeOfQuestion8 = 3;
			} else if (this.answer8 == "excellent") {
				this.gradeOfQuestion8 = 4;
			}

			var answerOfQuestion8 = {
				grade: this.gradeOfQuestion8,
				questionId: 8
			}

			if (this.answer9 == "poor") {
				this.gradeOfQuestion9 = 0;
			} else if (this.answer9 == "fair") {
				this.gradeOfQuestion9 = 1;
			} else if (this.answer9 == "good") {
				this.gradeOfQuestion9 = 2;
			} else if (this.answer9 == "veryGood") {
				this.gradeOfQuestion9 = 3;
			} else if (this.answer9 == "excellent") {
				this.gradeOfQuestion9 = 4;
			}

			var answerOfQuestion9 = {
				grade: this.gradeOfQuestion9,
				questionId: 9
			}

			this.listOfAnswers.push(answerOfQuestion1)
			this.listOfAnswers.push(answerOfQuestion2)
			this.listOfAnswers.push(answerOfQuestion3)
			this.listOfAnswers.push(answerOfQuestion4)
			this.listOfAnswers.push(answerOfQuestion5)
			this.listOfAnswers.push(answerOfQuestion6)
			this.listOfAnswers.push(answerOfQuestion7)
			this.listOfAnswers.push(answerOfQuestion8)
			this.listOfAnswers.push(answerOfQuestion9)

			axios.post('/api/survey', {
				title: 'Naslov ankete',
				commentSurvey: this.commentSurvey,
				answers: this.listOfAnswers,
				medicalExaminationId: this.medicalExaminationId
			}, {
				headers: {
				'Authorization': 'Bearer ' + this.userToken }
			}).then(response => {
				if (response.status === 200) {
					toast('Anketa je uspešno poslata')
					axios.put('/api/survey/filledSurveyForAppointment/' + this.appointmentId, {
						headers: {
						'Authorization': 'Bearer ' + this.userToken }
					}).then(response => {
						this.$router.push({ name: 'patientAppointments' })
					}).catch(error => {
						if (error.response.status === 401 || error.response.status === 403) {
							toast('Nemate pravo pristupa stranici!')
							this.$router.push({ name: 'userLogin' })
						}
					});
				}
			}).catch(error => {
				if (error.response.status === 401 || error.response.status === 403) {
					toast('Nemate pravo pristupa stranici!')
					this.$router.push({ name: 'userLogin' })
				}
			});
			
		},
		logOut: function () {
			localStorage.removeItem("validToken");
		}
	},
	computed: {

	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');

		axios.get('/api/doctor/getAllSpecialization', {
			headers: {
				'Authorization': 'Bearer ' + this.userToken
			}
		}).then(response => {

		}).catch(error => {
			if (error.response.status === 401 || error.response.status === 403) {
				toast('Nemate pravo pristupa stranici!')
				this.$router.push({ name: 'userLogin' })
			}
		});

		if (this.$route.params.medicalExaminationId !== null) {
			var appointment = this.$route.params.appointment;
			this.medicalExaminationId = appointment.medicalExaminationId;
			this.appointmentId = appointment.id;
		}	
	}
});