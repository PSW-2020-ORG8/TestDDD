Vue.component("patientMainPage", {
	data: function () {
		return {
            slideIndex: 1
		}
	},
	template: `
    <div>
    
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
                <li><a href="#/patientAppointments">Pregledi</a></li>
                <li><a href="#/">Utisci</a></li>
                <li class="active"><a href="">Početna</a></li>
                <li><a href="#/medicalRecordReview">Moj karton</a></li>
                <li><a href="#/patientDocumentsSimpleSearch">Dokumenti</a></li>
            </ul>
        </div>

        <div class="title-patient-main-page">
            <h1>Vaše zdravlje je u našim rukama!</h1>
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
	
        <div class="slideshow-container">

        <div class="mySlides fade">
            <!-- <div class="numbertext">1 / 3</div> -->
            <img src="./images/first.jpg" style="width:100%; height:480px; margin-bottom:-0.4%">
            <div class="text_pharmacy_name">
                <h1 style="color:black;float:left; font-size: 24px;">Apoteka: Janković </h1><br>
            </div>
            <div class="text_discount">
                <h1 style="color:black;float:left; font-size: 24px; ">Popust: 10%  </h1><br>
            </div>
            <div class="text_period">
                <h1 style="color:black;float:left; font-size: 24px; ">Period: 25.12.2020. - 01.01.2021.  </h1><br>
            </div>
            <div class="text_product">
                <h1 style="color:black;float:left; font-size: 24px; ">Proizvod: Sandoz lekovi  </h1><br>
            </div>
        </div>

        <div class="mySlides fade">
            <!--<div class="numbertext">2 / 3</div>-->
            <img src="./images/second.jpg" style="width:100%; height:480px; margin-bottom:-0.4%">
            <div class="text_pharmacy_name">
            <h1 style="color:black;float:left; font-size: 24px;">Apoteka: Zegin </h1><br>
            </div>
            <div class="text_discount">
                <h1 style="color:black;float:left; font-size: 24px; ">Popust: 30%  </h1><br>
            </div>
            <div class="text_period">
                <h1 style="color:black;float:left; font-size: 24px; ">Period: 15.12.2020. - 01.02.2021.  </h1><br>
            </div>
            <div class="text_product">
                <h1 style="color:black;float:left; font-size: 24px; ">Proizvod: Galenika lekovi </h1><br>
            </div>
        </div>

        <div class="mySlides fade">
            <!--<div class="numbertext">3 / 3</div>-->
            <img src="./images/third.jpg" style="width:100%; height:480px; margin-bottom:-0.4%">
            <div class="text_pharmacy_name">
            <h1 style="color:black;float:left; font-size: 24px;">Apoteka: Sarić </h1><br>
            </div>
            <div class="text_discount">
                <h1 style="color:black;float:left; font-size: 24px; ">Popust: 20%  </h1><br>
            </div>
            <div class="text_period">
                <h1 style="color:black;float:left; font-size: 24px; ">Period: 13.12.2020. - 13.02.2021.  </h1><br>
            </div>
            <div class="text_product">
                <h1 style="color:black;float:left; font-size: 24px; ">Proizvod: Pfizer lekovi  </h1><br>
            </div>
        </div>

        <a class="prev" @click="plusSlides(-1)">&#10094;</a>
        <a class="next" @click="plusSlides(1)">&#10095;</a>

        </div>
        <br>

        <div style="text-align:center; margin-left:-2%;">
            <span class="dot" @click="currentSlide(1)"></span>
            <span class="dot" @click="currentSlide(2)"></span>
            <span class="dot" @click="currentSlide(3)"></span>
        </div>
	 	  
	</div>
        
    `   
    ,
	components : {
		
    }
    ,
    computed : {	
				
	},
	methods: {
         showSlides: function(n) {
            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            if(n > slides.length) { this.slideIndex = 1 }
            if (n < 1) { this.slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" dot-active", "");
            }
            slides[this.slideIndex - 1].style.display = "block";
            dots[this.slideIndex - 1].className += " dot-active";
        },
        plusSlides: function(n) {
            this.showSlides(this.slideIndex += n);
        },
        currentSlide: function(n) {
            this.showSlides(this.slideIndex = n);
        },
        logOut: function () {
            localStorage.removeItem("validToken");
        }
               
	},
	mounted() {
        this.showSlides(this.slideIndex);
	}
});