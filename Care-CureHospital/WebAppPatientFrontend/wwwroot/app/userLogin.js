Vue.component("userLogin", {
	data: function (){
		return {
			usernameInput : false,
			passwordInput : false,
			username : '',
			password : '',
			returnData : '',
			notification : false
		}
	},
	template:`
	<div style="overflow: hidden;">
        <div class="logo-and-name-user-login">
            <div class="logo-user-login">        
                <img src="images/hospital.png"/>
            </div>
            <div class="web-name-user-login">
                <h3></h3>
            </div>  
        </div>

        <div class="main-user-login">     
            <ul class="menu-contents">
            <li><a href="#/">Početna</a></li>
            </ul>
        </div>  
	
        <div class="sign-in">
            <div class="form-container-user-login sign-in-container">
                <form id="form" class="formForLogin" action="#/homePage" method = "GET">
                    <br><h1 style="position: fixed;">Prijava</h1><br>
                    <label style="color:red;" v-if="notification">{{returnData}}</label><br>
                    <input type="text" name="username" v-model="username" placeholder="Korisničko ime"></input>
                    <label style="color:red;" v-if="usernameInput">Unesite korisničko ime!</label>
                    <label v-if="!usernameInput"></label><br>
                    <input type="password" name="password" v-model="password" placeholder="Lozinka"></input>
                    <label style="color:red;" v-if="passwordInput">Unesite lozinku!</label>
                    <label v-if="!passwordInput"></label><br>
                    <button type="submit" id="sign-in-button" v-on:click="onSubmit">Prijavi se</button><br><br>
                </form>
            </div>
            
            <div class="overlay-container">
                <div class="overlay">               
                    <div class="overlay-panel overlay-right">
                        <h1>Nemate nalog?</h1><br><br>
                        <p id="loginP">Kliknite ovde za registraciju!</p><br>
                        <button class="ghost" id="signUp" v-on:click="singUp">Registruj se</button>
                    </div>
                </div>
            </div>

        </div>

	</div>   
	`	
	,
	methods: {
		onSubmit : function() {
			this.usernameInput = false;
			this.passwordInput = false;	
            this.notification = false;
			
			document.getElementById("form").setAttribute("onsubmit","return false;");
            if (this.username.length === 0){
				this.usernameInput = true;			
			} else {
				this.usernameInput = false;
            } 
            if (this.password.length === 0) {
				this.passwordInput = true;	
			} else {
				this.passwordInput = false;			
			}

            if (this.usernameInput === false && this.passwordInput === false) {
                axios.post('api/user/login', {
                    username: this.username,
                    password: this.password
                }).then(response => {
                    var user = response.data
                    localStorage.setItem("validToken", user.token)
                    if (user.role === 'Admin') {
                        this.$router.push({ name: 'patientsFeedbacks' })
                    } else if (user.role === 'Patient') {
                        this.$router.push({ name: 'patientMainPage' })
                    }
                }).catch(error => {
                    if (error.response.status === 403) {
                        toast('Neuspešno korisničko ime ili lozinka')
                    }
                });
            }          
		},	
		singUp : function() {
			this.$router.push({ name: 'patientRegistration' })	
        },
        resetData : function() {
            this.notification = false;
            this.returnData = ""; 
        }		
	},
	mounted(){

	}
	
});