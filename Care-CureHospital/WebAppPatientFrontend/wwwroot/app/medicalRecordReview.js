function toLatinConvert(string) {
    var cyrillic = 'А_Б_В_Г_Д_Ђ_Е_Ё_Ж_З_И_Й_Ј_К_Л_Љ_М_Н_Њ_О_П_Р_С_Т_Ћ_У_Ф_Х_Ц_Ч_Џ_Ш_Щ_Ъ_Ы_Ь_Э_Ю_Я_а_б_в_г_д_ђ_е_ё_ж_з_и_й_ј_к_л_љ_м_н_њ_о_п_р_с_т_ћ_у_ф_х_ц_ч_џ_ш_щ_ъ_ы_ь_э_ю_я'.split('_')
    var latin = 'A_B_V_G_D_Đ_E_Ë_Ž_Z_I_J_J_K_L_Lj_M_N_Nj_O_P_R_S_T_Ć_U_F_H_C_Č_Dž_Š_Ŝ_ʺ_Y_ʹ_È_Û_Â_a_b_v_g_d_đ_e_ë_ž_z_i_j_j_k_l_lj_m_n_nj_o_p_r_s_t_ć_u_f_h_c_č_dž_š_ŝ_ʺ_y_ʹ_è_û_â'.split('_')

    return string.split('').map(function(char) {
      var index = cyrillic.indexOf(char)
      if (!~index)
        return char
      return latin[index]
    }).join('')
}


Vue.component("medicalRecordReview", {
	data: function () {
		return {
            medicalRecord: null,
            profilePicture: '',
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
                <li class="active"><a href="#/medicalRecordReview">Moj karton</a></li>
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

    <div class="fields-to-fill-medical-record">

        <div class="wrapper-form-medical-record">
            <div class="data-for-medical-record">
                <div class="text-for-medical-record">
                    <h1>Moj medicinski karton</h1>
                        <div class="scroll-in-medical-record">

                        <label class="scroll-in-medical-record-label-bold">Profilna slika:</label></br></br>
                        <img v-bind:src="'/images/patientsProfileImages/' + this.profilePicture" class="room-active" alt="" width="260px" height="200px"></img><br><br>

                        <label class="scroll-in-medical-record-label-bold">Korisničko ime:</label></br>
                        <label>{{medicalRecord.patient.username}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Ime:</label></br>
                        <label>{{medicalRecord.patient.name}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Ime jednog roditelja:</label></br>
                        <label>{{medicalRecord.patient.parentName}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Prezime:</label></br>
                        <label>{{medicalRecord.patient.surname}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Pol:</label></br>
                        <label v-if="medicalRecord.patient.gender === 0">Muški</label>
                        <label v-if="medicalRecord.patient.gender === 1">Ženski</label>

                        <br><br><br><label class="scroll-in-medical-record-label-bold">JMBG:</label></br>
                        <label>{{medicalRecord.patient.jmbg}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Broj lične karte:</label></br>
                        <label>{{medicalRecord.patient.identityCard}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Broj zdravstvene knjižice:</label></br>
                        <label>{{medicalRecord.patient.healthInsuranceCard}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Datum rođenja:</label></br>
                        <label>{{medicalRecord.dateOfBirthday}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Kontakt telefon:</label></br>
                        <label>{{medicalRecord.patient.contactNumber}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">E-mail:</label></br>
                        <label>{{medicalRecord.patient.eMail}}</label><br><br><br> 
                        
                        <label class="scroll-in-medical-record-label-bold">Mesto stanovanja:</label></br>
                        <label>{{medicalRecord.patient.city.name}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Adresa stanovanja:</label></br>
                        <label>{{medicalRecord.patient.city.address}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Država:</label></br>
                        <label>{{medicalRecord.patient.city.country.name}}</label><br><br><br> 

                        <label class="scroll-in-medical-record-label-bold">Krvna grupa:</label></br>
                        <label v-if="medicalRecord.patient.bloodGroup === 0">Nepoznata</label>
                        <label v-if="medicalRecord.patient.bloodGroup === 1">AB+</label>
                        <label v-if="medicalRecord.patient.bloodGroup === 2">AB-</label>
                        <label v-if="medicalRecord.patient.bloodGroup === 3">A+</label> 
                        <label v-if="medicalRecord.patient.bloodGroup === 4">A-</label>
                        <label v-if="medicalRecord.patient.bloodGroup === 5">B+</label>
                        <label v-if="medicalRecord.patient.bloodGroup === 6">B+</label>
                        <label v-if="medicalRecord.patient.bloodGroup === 7">0+</label>
                        <label v-if="medicalRecord.patient.bloodGroup === 8">0+</label>
                        
                        <br><br><br> <label class="scroll-in-medical-record-label-bold">Alergije:</label></br></br>
                        <div class="scroll-in-medical-record-allergies">
                            <template v-for="a in medicalRecord.allergies">
                                <label>{{a.name}}</label></br></br>
                            </template>   
                        </div></br>

                        <label class="scroll-in-medical-record-label-bold">Lekovi:</label></br></br>
                        <div class="scroll-in-medical-record-medicaments">
                            <template v-for="m in medicalRecord.medicaments" >
                                <label>{{m.name}}</label></br></br>
                            </template>
                        </div></br></br>
                   
                        <label class="scroll-in-medical-record-label-bold">Anamneza:</label></br>
                        <label>{{medicalRecord.anamnesis.description}}</label><br><br>
                        <label style="margin-left:-2%" class="scroll-in-medical-record-label-bold">Dijagnoze:</label>
                        <label style="margin-left:12%" class="scroll-in-medical-record-label-bold">Simptomi:</label><br>
                        <div class="scroll-in-medical-record-diagnosis">                            
                            <template v-for="d in medicalRecord.anamnesis.diagnosis" >
                                <label>{{d.name}}</label></br></br>
                            </template>
                        </div></br></br>
                        <div class="scroll-in-medical-record-symptoms">
                            <template v-for="s in medicalRecord.anamnesis.symptoms" >
                                <label>{{s.name}}</label></br></br>
                            </template>
                        </div></br>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>

	</div>
        
    `
    ,
	components : {

    }
    ,
	methods: {
        logOut: function () {
            localStorage.removeItem("validToken");
        }
	},
    mounted() {
        this.userToken = localStorage.getItem('validToken');
        axios.get('api/medicalRecord/getForPatient/' + 1, {
            headers: {
                'Authorization': 'Bearer ' + this.userToken
            }
        }).then(response => {
                this.medicalRecord = response.data;
                this.profilePicture = this.medicalRecord.profilePicture;
        }).catch(error => {
            if (error.response.status === 401 || error.response.status === 403) {
                toast('Nemate pravo pristupa stranici!')
                this.$router.push({ name: 'userLogin' })
            }
        });
	}
});