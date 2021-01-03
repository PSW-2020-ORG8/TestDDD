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


Vue.component("patientRegistration", {
	data: function () {
		return {
            showNotification : false,
            usernameInputField : '',
            errorForUsername : false,
            passwordInputField : '',
            confirmPasswordInputField : '',
            errorDifferentPassword : false,
            nameInputField : '',
            errorName : false,
            parentNameInputField : '',
            errorParentName : false,
            surnameInputField : '',
            errorSurname : false,
            genderSelectField : 'gender',
            jmbgInputField : '',
            errorJMBG : false,
            personalCardInputField : '',
            errorPersonalCard : false,
            healthBookletNumberInputField : '',
            errorHealthBookletNumber : false,
            dateOfBirthDatePicker : '',
            state : {
                disabledDates: {
                    from: new Date(),
                }
            },
            contactNumberField : '',
            errorContactNumber : false,
            emailField : '',
            errorEmail : false,
            places : null,
		    city : '',
		    zipCode : 0,
		    longitude : '',
		    latitude : '',
		    street : '',
		    number : '',
		    address: '',
            country : '',
            addressInput : '',
            errorAddress : false,
            imagesShow : [],
		    sendImage : '',
		    countImage : 0,
            disable : false,
            allergies : [],
            checkedAllergies : [],
            finalCheckedAllergies : [],
            modalDialog : false,
            allergyInputField : 'Bez alergija',
            bloodGroupInputField : 'unknown',
            emptyUsername : false,
            emptyPassword : false,
            emptyConfirmPassword : false,
            emptyName : false,
            emptyParentName : false,
            emptySurname : false,
            emptyGander : false,
            emptyJmbg : false,
            emptyPersonalCard : false,
            emptyHealthBookletNumber : false,
            emptyDateOfBirth : false,
            emptyContactNumber : false,
            emptyEmail : false,
            emptyAddress : false,
            finalAllergiesLists : [],
            foundAllergy: null
		}
	},
	template: `
    <div style="overflow: hidden">
    
    <div class="logo-and-name-patient-registration">
            <div class="logo-patient-registration ">        
                <img src="images/hospital.png"/>
            </div>
            <div class="web-name-patient-registration">
                <h3></h3>
            </div>  
        </div>

        <div class="main-patient-registration">     
            <ul class="menu-contents">
            <li><a href="#/">Početna</a></li>
            </ul>
        </div>

        <div class="dropdown">
            <button class="dropbtn">
                <img id="menuIcon" src="images/menuIcon.png" />
                <img id="userIcon" src="images/user.png" />
            </button>
        <div class="dropdown-content">
            <a>Registruj se</a>
            <a href="#/userLogin">Prijavi se</a>
        </div>
    </div>
	 
   
   <form id="form" action="" onsubmit="return false;"  method = "POST">
       <div class="confirm-cancel-field-patient-registration">
        <div class="confirm-cancel-field-patient-registration-title">
            <h1>Popunili ste potrebne podatke?</h1>
            <div class="add-btn-patient-registration">
                <button type="submit" @click="registerPatient()">Registruj se</button>
            </div>
            <div class="cancle-btn-patient-registration">
                <button type="button" @click="previousButtonClicked()">Odustani</button>
            </div>
            <label v-if="showNotification" style="color:red; margin-left: 20%; font-size: 20px">Morate popuniti sve podatke!</label>
        </div>
    </div>
   
    <div class="fields-to-fill-patient-registration">

        <div class="wrapper-form-patient-registration">
            <div class="data-for-patient-registration">
                <div class="text-for-patient-registration">
                    <h1>Podaci za registraciju</h1>
                        <div class="scroll-in-patient-registration">
                            <label v-if="emptyUsername" style="color:red;">Korisničko ime*:</label>
                            <label v-if="!emptyUsername">Korisničko ime*:</label>
                            <input v-model="usernameInputField" type="text" placeholder="Unesite korisničko ime..." pattern="[A-Za-zŠšĐđŽžČčĆć][A-Za-z0-9ŠšĐđŽžČčĆć]*" title="Možete uneti slova i brojeve!">
                            <label v-if="errorForUsername" style="color:red; font-size: 16px">Možete uneti slova i brojeve, prvi karakter mora biti slovo!</label><br><br>
                        
                            <label v-if="emptyPassword" style="color:red;">Lozinka*:</label>
                            <label v-else>Lozinka*:</label>
                            <input v-model="passwordInputField" type="password" placeholder="Unesite lozinku..."><br><br>

                            <label v-if="emptyConfirmPassword" style="color:red;">Potvrda lozinke*:</label>
                            <label v-else>Potvrda lozinke*:</label>
                            <input v-model="confirmPasswordInputField" type="password" placeholder="Unesite ponovo lozinku...">
                            <label v-if="errorDifferentPassword" style="color:red; font-size: 16px">Lozinke se ne poklapaju!</label><br><br>

                            <label v-if="emptyName" style="color:red;">Ime*:</label>
                            <label v-else>Ime*:</label>
                            <input v-model="nameInputField" type="text" placeholder="Unesite ime..." pattern="[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*" title="Prvo slovo mora biti veliko!">
                            <label v-if="errorName" style="color:red; font-size: 16px">Prvo slovo mora biti veliko!</label><br><br>

                            <label v-if="emptyParentName" style="color:red;">Ime jednog roditelja*:</label>
                            <label v-else>Ime jednog roditelja*:</label>
                            <input v-model="parentNameInputField" type="text" placeholder="Unesite ime jednog roditelja..." pattern="[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*" title="Prvo slovo mora biti veliko!">
                            <label v-if="errorParentName" style="color:red; font-size: 16px">Prvo slovo mora biti veliko!</label><br><br>

                            <label v-if="emptySurname" style="color:red;">Prezime*:</label>
                            <label v-else>Prezime*:</label>
                            <input v-model="surnameInputField" type="text" placeholder="Unesite prezime..." pattern="[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*" title="Prvo slovo mora biti veliko!">
                            <label v-if="errorSurname" style="color:red; font-size: 16px">Prvo slovo mora biti veliko!</label><br><br>

                            <label v-if="emptyGander" style="color:red;">Pol*:</label>
                            <label v-else>Pol*:</label>
                            <select v-model="genderSelectField">
                              <option value="gender">Izaberite pol...</option>
                              <option value="Male">Muško</option>
                              <option value="Female">Žensko</option>
                            </select><br><br>

                            <label v-if="emptyJmbg" style="color:red;">JMBG*:</label>
                            <label v-else>JMBG*:</label>
                            <input v-model="jmbgInputField" type="text" placeholder="Unesite JMBG..." pattern="[0-9]{13}" title="Možete uneti samo brojeve!">
                            <label v-if="errorJMBG" style="color:red; font-size: 16px">JMBG se sastoji od 13 cifara!</label><br><br>

                            <label v-if="emptyPersonalCard" style="color:red;">Broj lične karte*:</label>
                            <label v-else>Broj lične karte*:</label>
                            <input v-model="personalCardInputField" type="text" placeholder="Unesite broj lične karte..." pattern="[0-9]{9}" title="Možete uneti samo brojeve!">
                            <label v-if="errorPersonalCard" style="color:red; font-size: 16px">Lična karta se sastoji od 9 cifara!</label><br><br>

                            <label v-if="emptyHealthBookletNumber" style="color:red;">Broj zdravstvene knjižice*:</label>
                            <label v-else>Broj zdravstvene knjižice*:</label>
                            <input v-model="healthBookletNumberInputField" type="text" placeholder="Unesite broj zdravstvene knjižice..." pattern="[0-9]{11}" title="Možete uneti samo brojeve!">
                            <label v-if="errorHealthBookletNumber" style="color:red; font-size: 16px">Zdravstvene knjižice se sastoji od 11 cifara!</label><br><br>

                            <label v-if="emptyDateOfBirth" style="color:red;">Datum rođenja*:</label>
                            <label v-if="!emptyDateOfBirth" >Datum rođenja*:</label>
                            <vuejs-datepicker v-model="dateOfBirthDatePicker" type="date"  format="dd.MM.yyyy." :disabledDates="state.disabledDates" placeholder="Izaberite datum rođenja..." ></vuejs-datepicker><br>
                            
                            <label v-if="emptyContactNumber" style="color:red;">Kontakt telefon*:</label>
                            <label v-else>Kontakt telefon*:</label>
                            <input v-model="contactNumberField" type="text" placeholder="Unesite kontakt telefon..." pattern="[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*" title="Primer validnog kontakt telefona: +38166/123-123" >
                            <label v-if="errorContactNumber" style="color:red; font-size: 16px">Neispravan oblik kontakt telefona!</label><br><br>

                            <label v-if="emptyEmail" style="color:red;">E-mail*:</label>
                            <label v-else>E-mail*:</label>
                            <input v-model="emailField" type="text" placeholder="Unesite e-mail..." pattern="[\w-\.]+@([\w-]+\.)+[\w-]{2,4}" title="Primer za validan e-mail: pera.peric@gmail.com">
                            <label v-if="errorEmail" style="color:red; font-size: 16px">Neispravan oblik za e-mail!</label><br><br>

                            <label for="address" v-if="emptyAddress" style="color:red;">Adresa*:</label>
                            <label for="address" v-if="!emptyAddress">Adresa*:</label>
                            <input id="address" v-model="addressInput" placeholder="Unesite adresu apartmana..." type="search" ><br><br>
                            
                            <input id="latitude" hidden>
                            <input id="longitude" hidden>
                            <input id="city" hidden>
                            <input id="zipCode" hidden>
                            <input id="country" hidden>
                            <input id="number" hidden>

                            <label>Alergije:</label>
                            <input v-if="this.modalDialog === false" v-model="allergyInputField" :placeholder="[[ this.allergyInputField ]]" type="text"  @click="openModal()" >

                            <div v-if="this.modalDialog" class="modal-dialog-patient-registration">
                                <span class="span-allergies-patient-registration" v-for="allergy in allergies">        
                                    <label class="container-patient-registration">
                                    <input type="checkbox" :value="allergy.name" v-model="checkedAllergies">
                                    <div class="text-checkbox-patient-registration">{{allergy.name}}</div>
                                    <span class="checkmark-patient-registration"></span>
                                    </label>
                                </span>

                                <div class="close-btn-patient-registration">
                                    <button type="button" @click="closeModal()">Sačuvaj</button>
                                </div>
                            </div>

                            <br><br><label>Krvna grupa:</label>
                            <select v-model="bloodGroupInputField">
                              <option value="unknown">Nepoznato</option>
                              <option value="AbPlus">AB+</option>
                              <option value="AbMinus">AB-</option>
                              <option value="APlus">A+</option>
                              <option value="AMinus">A-</option>
                              <option value="BPlus">B+</option>
                              <option value="BMinus">B-</option>
                              <option value="OPlus">O+</option>
                              <option value="OMinus">O-</option>
                            </select><br><br>

                            <label>Profilna slika:</label><br><br>
                            <input v-if="this.countImage <= 1" type="file"   @change="addImage" >
                            <input v-else type="file" disabled  @change="addImage"><br><br><br>
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
		vuejsDatepicker
    }
    ,
	methods: {
		registerPatient : function () {
            var empty = false;
            var madeDateOfBirth = null;
            this.showNotification = false;
            this.errorForUsername = false;
            this.errorDifferentPassword = false;
            this.errorName = false;
            this.errorParentName = false;
            this.errorSurname = false;
            this.errorJMBG = false;
            this.errorHealthBookletNumber = false;
            this.errorContactNumber = false;
            this.errorEmail = false;
            this.errorAddress = false;
            this.errorPersonalCard = false;
            this.emptyUsername = false;
            this.emptyPassword = false;
            this.emptyConfirmPassword = false;
            this.emptyName = false;
            this.emptyParentName = false;
            this.emptySurname = false;
            this.emptyGander = false;
            this.emptyJmbg = false;
            this.emptyPersonalCard = false;
            this.emptyHealthBookletNumber = false;
            this.emptyDateOfBirth = false;
            this.emptyContactNumber = false;
            this.emptyEmail = false;
            this.emptyAddress = false;

            if(this.usernameInputField.length === 0) {
                empty = true;
                this.emptyUsername = true;
			} else {
				if(!this.usernameInputField.match(/^[A-Za-zŠšĐđŽžČčĆć][A-Za-z0-9ŠšĐđŽžČčĆć]*$/)){
					this.errorForUsername = true;
                    empty = true;
                    this.emptyUsername = true;
                }               
            }
            
            if(this.passwordInputField.length === 0) {
                empty = true;
                this.emptyPassword = true;
                if(this.confirmPasswordInputField.length === 0) {
                    this.emptyConfirmPassword = true;
                }
            } else {
				if(this.passwordInputField !== this.confirmPasswordInputField){
                    this.errorDifferentPassword = true;
                    this.emptyPassword = true;
                    this.emptyConfirmPassword = true;
				}
            }

            if(this.nameInputField.length === 0) {
                empty = true;
                this.emptyName = true;
			} else {
				if(!this.nameInputField.match(/^[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*$/)){
					this.errorName = true;
                    empty = true;
                    this.emptyName = true;
				}
            }

            if(this.parentNameInputField.length === 0) {
                empty = true;
                this.emptyParentName = true;
			} else {
				if(!this.parentNameInputField.match(/^[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*$/)){
					this.errorParentName = true;
                    empty = true;
                    this.emptyParentName = true;
				}
            }

            if(this.surnameInputField.length === 0) {
                empty = true;
                this.emptySurname = true;
			} else {
				if(!this.surnameInputField.match(/^[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*$/)){
					this.errorSurname = true;
                    empty = true;
                    this.emptySurname = true;
				}
            }

            if(this.genderSelectField === 'gender') {
                empty = true;
                this.emptyGander = true;
			} 
            
            if(this.jmbgInputField.length === 0) {
                empty = true;
                this.emptyJmbg = true;
			} else {
				if(!this.jmbgInputField.match(/^[0-9]{13}$/)){
					this.errorJMBG = true;
                    empty = true;
                    this.emptyJmbg = true;
				}
            }

            if(this.personalCardInputField.length === 0) {
                empty = true;
                this.emptyPersonalCard = true;
			} else {
				if(!this.personalCardInputField.match(/^[0-9]{9}$/)){
					this.errorPersonalCard = true;
                    empty = true;
                    this.emptyPersonalCard = true;
				}
            }

            if(this.healthBookletNumberInputField.length === 0) {
                empty = true;
                this.emptyHealthBookletNumber = true;
			} else {
				if(!this.healthBookletNumberInputField.match(/^[0-9]{11}$/)){
					this.errorHealthBookletNumber = true;
                    empty = true;
                    this.emptyHealthBookletNumber = true;
				}
            }
            
            if(this.dateOfBirthDatePicker === null || this.dateOfBirthDatePicker.length === 0) {
                empty = true;
                this.emptyDateOfBirth = true;
			} else {
				let date = moment(this.dateOfBirthDatePicker).format("YYYY-MM-DD");
				madeDateOfBirth = new Date(date);	
            }
            
            if(this.contactNumberField.length === 0) {
                empty = true;
                this.emptyContactNumber = true;
			} else {
				if(!this.contactNumberField.match(/^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$/)){
					this.errorContactNumber = true;
                    empty = true;
                    this.emptyContactNumber = true;
				}
            }

            if(this.emailField.length === 0) {
                empty = true;
                this.emptyEmail = true;
			} else {
				if(!this.emailField.match(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/)){
					this.errorEmail = true;
                    empty = true;
                    this.emptyEmail = true;
				}
            }

            if(this.addressInput.length === 0 ){
                empty = true;	
                this.emptyAddress = true;		
			}else{
				this.address = toLatinConvert(document.querySelector('#address').value);
				this.longitude = toLatinConvert(document.querySelector('#longitude').value);
				this.latitude = toLatinConvert(document.querySelector('#latitude').value);
				this.city = toLatinConvert(document.querySelector('#city').value);
				this.zipCode = toLatinConvert(document.querySelector('#zipCode').value);
				this.country = toLatinConvert(document.querySelector('#country').value);
				//this.number = document.querySelector('#number').value;
				try {
                    var streetAndNumber = this.address.split(/(\d+)/);
                    this.street = streetAndNumber[0].trim();
                    this.number = streetAndNumber[1].trim();
                } catch (error) {
                    this.street = this.address;
                    this.number = '';
                }
	
				
				if(this.country === "Serbia"){
					this.country = "Srbija";
				}
				
			}

			if (empty === false) {	
                if(!this.errorDifferentPassword){
                    for(allergyId in this.checkedAllergies){
                        
                        var allergy = {
                            Name: allergyId
                        }
                        this.finalAllergiesLists.push(allergy)
                    }

                    axios.post('/api/medicalRecord', {
                        "Patient" : {"Username" : this.usernameInputField, "Password" : this.passwordInputField, "GuestAccount" : false,
                        "Name" : this.nameInputField , "ParentName" : this.parentNameInputField, "Surname" : this.surnameInputField,
                        "Jmbg" : this.jmbgInputField, "IdentityCard" : this.personalCardInputField, "HealthInsuranceCard" : this.healthBookletNumberInputField, 
                        "BloodGroup" : this.bloodGroupInputField, "DateOfBirth" : madeDateOfBirth, "Gender" : this.genderSelectField, "ContactNumber" : this.contactNumberField, "EMail" : this.emailField, 
                        "City" : {"Name" : this.city, "PostCode" : this.zipCode, "Address" : this.street + ' ' + this.number, 
                        "Country" : {"Name" : this.country}}},
                        "allergies" : this.finalAllergiesLists,
                        "ConfirmedPassword" : this.confirmPasswordInputField,
                        "ActiveMedicalRecord" : false,
                        "ProfilePicture" : this.sendImage
                    }).then(response => {
                        if(response.status === 200){
                            toast('Uspešno ste se registrovali, potvrdite Vaš identitet putem mejla')
                            this.resetData()          
                        }           
                    }).catch(error => {
			            if(error.response.status === 400){
                            toast('Korisničko ime već postoji!')
                            this.emptyUsername = true;
                        }
                    });
                    
                }		 	
			} else {
                this.showNotification = true; 
            }
        },
        openModal : function(){
            this.modalDialog = true;
        },
        closeModal : function(){
            this.modalDialog = false;
            if(this.checkedAllergies.length > 0 ){
                this.allergyInputField = 'Alergije su uspešno izabrane';    
            } else {
                this.allergyInputField = 'Bez alergija';
            }          
        },
        previousButtonClicked : function(){	

            if(confirm('Da li ste sigurni da želite da odustanete od registracije?') === true){ 
                this.resetData()
            }
        },       
        addImage : function(e){
			const file = e.target.files[0];
			this.createBase64Image(file);
			this.countImage++;
			if(this.countImge === 1){
				this.disabled = true;
			}
			this.imagesShow.push(URL.createObjectURL(file));
		},		
		createBase64Image : function(file){		
			const reader = new FileReader();
			reader.onload = (e) => {
				this.sendImage = e.target.result;						
			}		
			reader.readAsDataURL(file);
        },
        resetData : function(){
            this.usernameInputField = '';
            this.passwordInputField = '';
            this.confirmPasswordInputField =  '';
            this.nameInputField =  '';
            this.parentNameInputField =  '';
            this.surnameInputField =  '';
            this.genderSelectField =  'gender';
            this.jmbgInputField =  '';
            this.personalCardInputField =  '';
            this.healthBookletNumberInputField =  '';
            this.dateOfBirthDatePicker =  '';
            this.contactNumberField = '';
            this.emailField = '';
            this.places = null;
            this.city = '';
            this.zipCode = 0;
            this.longitude = '';
            this.latitude = '';
            this.street = '';
            this.number = '';
            this.address = '';
            this.country = '';
            this.addressInput = '';
            this.checkedAllergies =  [];
            this.finalCheckedAllergies =  [];
            this.modalDialog = false;
            this.allergyInputField = 'Bez alergija';
            this.bloodGroupInputField = 'unknown';
            this.sendImage = '';
		    this.countImage = 0;
            this.disable = false;
        }
	},
    mounted() {
        axios.get('api/allergies').then(response => {
            this.allergies = response.data;
        });

        this.places = places({
			appId: 'plQ4P1ZY8JUZ',
			apiKey: 'bc14d56a6d158cbec4cdf98c18aced26',
			container: document.querySelector('#address'),
			templates: {
					value: function(suggestion){
						return suggestion.name;
				    }
			}
			}).configure({
					type: 'address'			
		});
		
		this.places.on('change', function getLocationData(e){		
			document.querySelector('#address').value = e.suggestion.value || '';
			document.querySelector('#city').value = e.suggestion.city || '';
			document.querySelector('#longitude').value = e.suggestion.latlng.lng || '';
			document.querySelector('#latitude').value = e.suggestion.latlng.lat || '';
			document.querySelector('#zipCode').value = e.suggestion.postcode || '';
			document.querySelector('#country').value = e.suggestion.country || '';
		});
	}

});