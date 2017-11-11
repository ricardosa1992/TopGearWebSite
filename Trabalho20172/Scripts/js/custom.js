// Custom JS for the Theme

// Config 
//-------------------------------------------------------------

var companyName = "Car Rental Station"; // Enter your event title


// Initialize Tooltip  
//-------------------------------------------------------------

$('.my-tooltip').tooltip();



// Initialize jQuery Placeholder  
//-------------------------------------------------------------

$('input, textarea').placeholder();



// Toggle Header / Nav  
//-------------------------------------------------------------

$(document).on("scroll",function(){
  if($(document).scrollTop()>39){
      $("header").removeClass("large").addClass("small");
      $(".nav").css({ 'display': 'none'});
  }
  else{
      $("header").removeClass("small").addClass("large");
      $(".nav").css({ 'display': 'block' });
  }

});

//floatingMenu.add('divreserva',
//     {
//         // Represents distance from left or right browser window  
//         // border depending upon property used. Only one should be  
//         // specified.  
//         // targetLeft: 0,  
//         targetRight: 10,

//         // Represents distance from top or bottom browser window  
//         // border depending upon property used. Only one should be  
//         // specified.  
//         targetTop: 10,
//         // targetBottom: 0,  

//         // Uncomment one of those if you need centering on  
//         // X- or Y- axis.  
//         // centerX: true,  
//         // centerY: true,  

//         // Remove this one if you don't want snap effect  
//         snap: true
//     });

$(window).scroll(function () {
    //var margem = 10;
    //var posicao = $(document).scrollTop() + window.innerHeight;
    //var footertop = $('#footer').offset().top;
    //var meiodapagina = window.innerHeight / 2;
    //var maximo = footertop + meiodapagina - margem;

    //if (posicao < maximo) {
    //    $('#divReserva').css('bottom', meiodapagina + 'px');
    //} else {
    //    $('#divReserva').css('bottom', (margem + (posicao - footertop)) + 'px');
    //}

});


// Vehicles Tabs / Slider  
//-------------------------------------------------------------

$(".vehicle-data").hide();
var activeVehicleData = $(".vehicle-nav .active a").attr("href");
$(activeVehicleData).show();

$('.vehicle-nav-scroll').click(function(){
    var direction = $(this).data('direction');
    var scrollHeight = $('.vehicle-nav li').height() + 1;
    var navHeight = $('#vehicle-nav-container').height() + 1;
    var actTopPos = $(".vehicle-nav").position().top;
    var navChildHeight = $('#vehicle-nav-container').find('.vehicle-nav').height();
    var x = -(navChildHeight - navHeight);

    var fullHeight = 0;
    $('.vehicle-nav li').each(function() {
        fullHeight += scrollHeight;
    });

    navHeight = fullHeight - navHeight + scrollHeight;

    // Scroll Down
    if ((direction == 'down') && (actTopPos > x) && (-navHeight <= (actTopPos - (scrollHeight * 2)))) {
        topPos = actTopPos - scrollHeight;
        $(".vehicle-nav").css('top', topPos);
    }

    // Scroll Up
    if (direction == 'up' && 0 > actTopPos) {
        topPos = actTopPos + scrollHeight;
        $(".vehicle-nav").css('top', topPos);
    }

    return false;
});




$(".vehicle-nav li").on("click", function(){

  $(".vehicle-nav .active").removeClass("active");
  $(this).addClass('active');

  $(activeVehicleData).fadeOut( "slow", function() {
    activeVehicleData = $(".vehicle-nav .active a").attr("href");
    $(activeVehicleData).fadeIn("slow", function() {});
  });

  return false;
});



// Vehicles Responsive Nav  
//-------------------------------------------------------------

$("<div />").appendTo("#vehicle-nav-container").addClass("styled-select-vehicle-data");
$("<select />").appendTo(".styled-select-vehicle-data").addClass("vehicle-data-select");
$("#vehicle-nav-container a").each(function() {
  var el = $(this);
  $("<option />", {
    "value"   : el.attr("href"),
    "text"    : el.text()
  }).appendTo("#vehicle-nav-container select");
});

$(".vehicle-data-select").change(function(){
  $(activeVehicleData).fadeOut( "slow", function() {
    activeVehicleData = $(".vehicle-data-select").val();
    $(activeVehicleData).fadeIn("slow", function() {});
  });

  return false;
});



// Initialize Datepicker
//-------------------------------------------------------------------------------
$.fn.datepicker.defaults.format = "dd/mm/yyyy";
var nowTemp = new Date();
var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

var checkin = $('#pick-up-date').datepicker({
    onRender: function (date) {
        return date.valueOf() < now.valueOf() ? 'disabled' : '';
    }
}).on('changeDate', function (ev) {
    if (ev.date.valueOf() > checkout.date.valueOf()) {
        var newDate = new Date(ev.date)
        newDate.setDate(newDate.getDate() + 1);
        checkout.setValue(newDate);
    }
    checkin.hide();
    $('#drop-off-date')[0].focus();
}).data('datepicker');
var checkout = $('#drop-off-date').datepicker({
    onRender: function (date) {
        return date.valueOf() < checkin.date.valueOf() ? 'disabled' : '';
    }
}).on('changeDate', function (ev) {
    checkout.hide();
}).data('datepicker');



// Toggle Drop-Off Location
//-------------------------------------------------------------------------------
$(".input-group.drop-off").hide();
$(".different-drop-off").on("click", function(){
	$(".input-group.drop-off").toggle();
  $(".autocomplete-suggestions").css("width", $('.pick-up .autocomplete-location').outerWidth());
  return false;
});



// Scroll to Top Button
//-------------------------------------------------------------------------------

$(window).scroll(function(){
  if ($(this).scrollTop() > 100) {
    $('.scrollup').removeClass("animated fadeOutRight");
    $('.scrollup').fadeIn().addClass("animated fadeInRight");
  } else {
    $('.scrollup').removeClass("animated fadeInRight");
    $('.scrollup').fadeOut().addClass("animated fadeOutRight");
  }
});

$('.scrollup, .navbar-brand').click(function(){
  $("html, body").animate({ scrollTop: 0 }, 'slow', function(){
    $("nav li a").removeClass('active');
  });
  return false;
});



// Location Map Function
//-------------------------------------------------------------------------------

function loadMap(addressData){

  var path = document.URL;
      path = path.substring(0, path.lastIndexOf("/") + 1)

  var locationContent = "<h2>"+companyName+"</h2>"
  + "<p>"+addressData.value+"</p>";

  var locationData = {
        map: {
            options: {
                maxZoom: 15,
                scrollwheel: false,
            }
        },
        infowindow:{
                options:{
                content: locationContent
            }
        },
        marker:{
            options: {
                icon: new google.maps.MarkerImage(
                    path+"img/mapmarker.png",
                    new google.maps.Size(59, 58, "px", "px"),
                    new google.maps.Point(0, 0),    //sets the origin point of the icon
                    new google.maps.Point(29, 34)   //sets the anchor point for the icon
                )
            }
        }
    };

    if ($.isEmptyObject(addressData.latLng)) {
        locationData.infowindow.address = addressData.value;
        locationData.marker.address = addressData.value;
    }
    else{
        locationData.infowindow.latLng = addressData.latLng;
        locationData.marker.latLng = addressData.latLng;
    }

  $('#locations .map').gmap3(locationData, "autofit" );
}

loadMap(locations[0]);


$("#location-map-select").append('<option value="'+locations[0].value+'">Please select a location</option>');  
$.each(locations, function( index, value ) {
  //console.log(index);
  var option = '<option value="'+index+'">'+value.value+'</option>';
  $("#location-map-select").append(option);
});

$('#location-map-select').on('change', function() {
  $('#locations .map').gmap3('destroy');
  loadMap(locations[this.value]);
});



// Scroll To Animation
//-------------------------------------------------------------------------------

var scrollTo = $(".scroll-to");

scrollTo.click( function(event) {
  $('.modal').modal('hide');
  var position = $(document).scrollTop();
  var scrollOffset = 110;

  if(position < 39)
  {
    scrollOffset = 260;
  }

  var marker = $(this).attr('href');
  $('html, body').animate({ scrollTop: $(marker).offset().top - scrollOffset}, 'slow');

  return false;
});



// setup autocomplete - pulling from locations-autocomplete.js
//-------------------------------------------------------------------------------

$('.autocomplete-location').autocomplete({
  lookup: locations
});


// Newsletter Form
//-------------------------------------------------------------------------------

$( "#newsletter-form" ).submit(function() {

  $('#newsletter-form-msg').addClass('hidden');
  $('#newsletter-form-msg').removeClass('alert-success');
  $('#newsletter-form-msg').removeClass('alert-danger');

  $('#newsletter-form input[type=submit]').attr('disabled', 'disabled');

  $.ajax({
    type: "POST",
    url: "php/index.php",
    data: $("#newsletter-form").serialize(),
    dataType: "json",
    success: function(data) {

      if('success' == data.result)
      {
        $('#newsletter-form-msg').css('visibility','visible').hide().fadeIn().removeClass('hidden').addClass('alert-success');
        $('#newsletter-form-msg').html(data.msg[0]);
        $('#newsletter-form input[type=submit]').removeAttr('disabled');
        $('#newsletter-form')[0].reset();
      }

      if('error' == data.result)
      {
        $('#newsletter-form-msg').css('visibility','visible').hide().fadeIn().removeClass('hidden').addClass('alert-danger');
        $('#newsletter-form-msg').html(data.msg[0]);
        $('#newsletter-form input[type=submit]').removeAttr('disabled');
      }

    }
  });

  return false;
});



// Contact Form
//-------------------------------------------------------------------------------

$( "#contact-form" ).submit(function() {

  $('#contact-form-msg').addClass('hidden');
  $('#contact-form-msg').removeClass('alert-success');
  $('#contact-form-msg').removeClass('alert-danger');

  $('#contact-form input[type=submit]').attr('disabled', 'disabled');

  $.ajax({
    type: "POST",
    url: "php/index.php",
    data: $("#contact-form").serialize(),
    dataType: "json",
    success: function(data) {

      if('success' == data.result)
      {
        $('#contact-form-msg').css('visibility','visible').hide().fadeIn().removeClass('hidden').addClass('alert-success');
        $('#contact-form-msg').html(data.msg[0]);
        $('#contact-form input[type=submit]').removeAttr('disabled');
        $('#contact-form')[0].reset();
      }

      if('error' == data.result)
      {
        $('#contact-form-msg').css('visibility','visible').hide().fadeIn().removeClass('hidden').addClass('alert-danger');
        $('#contact-form-msg').html(data.msg[0]);
        $('#contact-form input[type=submit]').removeAttr('disabled');
      }

    }
  });

  return false;
});



// Car Select Form
//-------------------------------------------------------------------------------
$("#car-select-form").submit(function () {
      var pickupLocation = $("#listaLocalRetirada").val();
      var pickUpDate = $("#pick-up-date").val();
      var pickUpTime = $("#pick-up-time").val();
      var dropOffDate = $("#drop-off-date").val();
      var dropOffTime = $("#drop-off-time").val();

      var error = 0;

      if (validateNotEmpty(pickupLocation) || pickupLocation == 0) { error = 1; }
      if(validateNotEmpty(pickUpDate)) { error = 1; }
      if(validateNotEmpty(dropOffDate)) { error = 1; }

      if (error == 1)
      {

          $('#car-select-form-msg').css('visibility', 'visible').hide().fadeIn().removeClass('hidden').delay(2000).fadeOut();
          return false;

      }

});

//$( "#car-select-form" ).submit(function() {

//  var selectedCar = $("#car-select").find(":selected").text();
//  var selectedCarVal = $("#car-select").find(":selected").val();
//  var selectedCarImage = $("#car-select").val();
//  var pickupLocation = $("#pick-up-location").val();
//  var dropoffLocation = $("#drop-off-location").val();
//  var pickUpDate = $("#pick-up-date").val();
//  var pickUpTime = $("#pick-up-time").val();
//  var dropOffDate = $("#drop-off-date").val();
//  var dropOffTime = $("#drop-off-time").val();

//  var error = 0;

//  if(validateNotEmpty(selectedCarVal)) { error = 1; }
//  if(validateNotEmpty(pickupLocation)) { error = 1; }
//  if(validateNotEmpty(pickUpDate)) { error = 1; }
//  if(validateNotEmpty(dropOffDate)) { error = 1; }

//  if(0 == error)
//  {

//    $("#selected-car-ph").html(selectedCar);
//    $("#selected-car").val(selectedCar);
//    $("#selected-vehicle-image").attr('src', selectedCarImage);

//    $("#pickup-location-ph").html(pickupLocation);
//    $("#pickup-location").val(pickupLocation);
    
//    if("" == dropoffLocation)
//    {
//      $("#dropoff-location-ph").html(pickupLocation);
//      $("#dropoff-location").val(pickupLocation);
//    }
//    else
//    {
//      $("#dropoff-location-ph").html(dropoffLocation);
//      $("#dropoff-location").val(dropoffLocation);
//    }
    
//    $("#pick-up-date-ph").html(pickUpDate);
//    $("#pick-up-time-ph").html(pickUpTime);
//    $("#pick-up").val(pickUpDate+' at '+pickUpTime);

//    $("#drop-off-date-ph").html(dropOffDate);
//    $("#drop-off-time-ph").html(dropOffTime);
//    $("#drop-off").val(dropOffDate+' at '+dropOffTime);

//    $('#checkoutModal').modal();
//  }
//  else
//  {
//    $('#car-select-form-msg').css('visibility','visible').hide().fadeIn().removeClass('hidden').delay(2000).fadeOut();
//  }

//  return false;
//});



// Check Out Form
//-------------------------------------------------------------------------------

$( "#checkout-form" ).submit(function() {

  $('#checkout-form-msg').addClass('hidden');
  $('#checkout-form-msg').removeClass('alert-success');
  $('#checkout-form-msg').removeClass('alert-danger');

  $('#checkout-form input[type=submit]').attr('disabled', 'disabled');

  $.ajax({
    type: "POST",
    url: "php/index.php",
    data: $("#checkout-form").serialize(),
    dataType: "json",
    success: function(data) {

      if('success' == data.result)
      {
        $('#checkout-form-msg').css('visibility','visible').hide().fadeIn().removeClass('hidden').addClass('alert-success');
        $('#checkout-form-msg').html(data.msg[0]);
        $('#checkout-form input[type=submit]').removeAttr('disabled');

        setTimeout(function(){
          $('.modal').modal('hide');
          $('#checkout-form-msg').addClass('hidden');
          $('#checkout-form-msg').removeClass('alert-success');

          $('#checkout-form')[0].reset();
          $('#car-select-form')[0].reset();
        }, 5000);

      }

      if('error' == data.result)
      {
        $('#checkout-form-msg').css('visibility','visible').hide().fadeIn().removeClass('hidden').addClass('alert-danger');
        $('#checkout-form-msg').html(data.msg[0]);
        $('#checkout-form input[type=submit]').removeAttr('disabled');
      }

    }
  });

return false;
});





//Chama o Método que faz a Locação
$("#efetuarLocacao").click(function (e) {
    debugger;
    $.ajax({
        url: "/Locacao/Efetuarlocacao",
        type: "POST",
        dataType: 'json',
        data: {
            idCarro: $("#idCarroSelecionadoHidden").val(),
            idLocalRetirada: $("#idLocalRetiradaHidden").val(),
            idLocalEntrega: $("#idLocalEntregaHidden").val(),
            dataRetirada: $("#dataRetiradaHidden").val(),
            dataEntrega: $("#dataEntregaHidden").val(),
            precoTotal: ($("#precoTotal").val()).replace(".", ",")
        },
        success: function (result) {
            if (result.Status == "ok") {
                swal({
                    title: 'Locacao efetuada com sucesso!',
                    type: 'success'
                });
            }
            else {
                swal({
                    title: "Ocorreu algum erro na gravação\n Tente novamente!",
                    type: "error"
                });
            }
        }
    });

});

$("#cpfUser, #senhaUser").click(function (e) {
    $(this).css({ 'border': '#cccccc solid 1px' });
    $(this).closest('div').find('.msgErro').hide();

});




//
$("#opLogout").click(function (e) {
    $.ajax({
        type: "POST",
        url: "/Acesso/SairSessao",
        dataType: "json",
        success: function (data) {
            $("IdCliente").val("");
            $("#opLogin").show;
            $("#opReservas").hide();
            $("#opLogout").hide();
        }
    });


});

//Abre o modal para cadastro do cliente
$("#btn-cadastro").click(function (e) {
    $("#modal-login").modal('toggle');
    $("#modal-cadastro").modal();

});


//Função de Cadastro
//---------------------------------------------------------------
$("#form-cadastro-cliente").submit(function (e) {
    debugger;
    var endereco = $("#rua").val() + ", " + $("#Bairro").val() + ", " + $("#cidade").val() + ", " + $("#estado").val(); 
    $("#Endereco").val(endereco);

    var url = "Base/CadastrarCliente"; // the script where you handle the form input.

    $.ajax({
        type: "POST",
        url: url,
        data: $("#form-cadastro-cliente").serialize(), // serializes the form's elements.
        success: function (result) {
            if (result.Status == "ok") {
                $("#modal-cadastro").modal('toggle');
                $.ajax({
                    url: "/Acesso/EfetuarLogin",
                    type: "POST",
                    dataType: 'json',
                    data: {
                        login: $("#cpf").val().replace(".", "").replace(".", "").replace("-", ""),
                        senha: $("#senha").val()
                    },
                    success: function (result) {
                        if (result.Status == "ok") {
                            debugger
                            $("#IdCliente").val(result.IdCliente);
                            $("#nomeCliente").text(result.Nome);
                            $("#opLogin").hide();
                            $("#opReservas").show();
                            $("#opLogout").show();
                        }
                    }
                });
            }
        }
    });

    e.preventDefault(); // avoid to execute the actual submit of the form.
});
//-------------------------------------------------------------


//------------------------------------------------------------
//Máscara dos campos
$('.data').mask('00/00/0000');
$('.tel').mask('(00) 0000-0000');
$('.cartao').mask('0000-0000-0000-0000');



// Not Empty Validator Function
//-------------------------------------------------------------------------------

function validateNotEmpty(data){
  if (data == ''){
    return true;
  }else{
    return false;
  }
}

function formatar(mascara, documento) {
    var i = documento.value.length;
    var saida = mascara.substring(0, 1);
    var texto = mascara.substring(i);
    if (texto.substring(0, 1) != saida)
    {
        documento.value += texto.substring(0, 1);
    }
}

function EfetuarLogin(cpf, senha) {
    $.ajax({
        url: "/Acesso/EfetuarLogin",
        type: "POST",
        dataType: 'json',
        data: {
            login: cpf,
            senha: senha
        },
        success: function (result) {
            if (result.Status == "ok") {
                $("#IdCliente").val(result.IdCliente);
                $("#nomeCliente").text(result.Nome);
                $("#modal-login").modal('toggle');
                $("#opLogin").hide();
                $("#opReservas").show();
                $("#opLogout").show();
            }
            else {
                $("#msgErroLogin").show();

            }
        }
    });
}

