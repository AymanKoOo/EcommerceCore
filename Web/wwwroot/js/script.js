// function extend(Child,Parent){
//   Child.prototype = Object.create(Parent.prototype);
//   Child.prototype.constructor = Parent;
// }
// function Cat(){
// }

// Cat.prototype.walk = function(){
// console.log("aa");
// }

// let cat = new Cat();
// console.log(cat);

// function aa(){


// }
// extend(aa,Cat);
// let b = new aa();
// console.log(b);


// function myFunction(event) {
//   var x = event.offsetX;
//   console.log("aa");
// }


// document.querySelector("#panel").addEventListener("click",function(event){
// var x= event.offsetX;
// var y=event.offsetY;

// console.log(x,y)

// var square = document.createElement("div");
// var widthh =String(console.log(Math.abs(x-y)));
// square.style.width="25px";
// square.style.height="25px";
// square.style.position="absolute";
// square.style.left=x+"px";
// square.style.top=y+"px";
// square.style.backgroundColor="black"
// square.style.animation
// console.log(square);
// var panel = document.querySelector("#panel");
// panel.appendChild(square);

// })

// document.querySelector("#bb").addEventListener("change",function(event){
//  console.log(event.target.value);
// })

// //foreach https://stackoverflow.com/questions/14544104/checkbox-check-event-listener
// document.querySelector("input[name=checkbox]").addEventListener("change",function(event){
// console.log(event.target.value);
// })
/////////////////////////////
// var items = document.querySelectorAll(".products li");
// var cart = document.getElementById("crt");
// items.forEach(function(item){
//   item.onclick = function(){
//      cart.innerHTML+=item.textContent;
//   }})

//   const data = null;

// const xhr = new XMLHttpRequest();


// xhr.onreadystatechange= function(){

//   if(this.status==200){
//      console.log(JSON.parse(xhr.responseText))    
//   }

// };
// xhr.open("GET","httt");
// xhr.send();

// $(document).ready(function(){

//   $("button").animate(){

//   }

//   var t = $("div").text(); // get text in that div

//   $("div").text("aaaa");
//   $("div").html("aaaa");
//   $("input").val("")
//   $("input").attr("id","33");
//   $("input").attr("id")
//   $("p").addClass("test")
//   $('aa').removeClass("aa");
//   $('aa').css("aa");
//   $('aa').toggleClass("red");
//   $('aa').on("click".function(){

//   })

//   document.getElementById("dd").addClass("test");
//   //.innerhtml

//   });




// });





// /////////////////////////////////////
$('.carousel').carousel({
    interval: 7000
})

$(document).ready(function () {

    $(".tb").hover(function () {

        $(".tb").removeClass("tb-active");
        $(this).addClass("tb-active");

        current_fs = $(".active");

        next_fs = $(this).attr('id');
        next_fs = "#" + next_fs + "1";

        $("fieldset").removeClass("active");
        $(next_fs).addClass("active");

        current_fs.animate({}, {
            step: function () {
                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                next_fs.css({
                    'display': 'block'
                });
            }
        });
    });

});


function changeColor(cid) {

    const color = document.getElementById(cid);

    const accordionItems = [...document.getElementsByClassName('color')]
    accordionItems.forEach(accordionItem => {
        accordionItem.classList.remove('onColor')
    })

    color.classList.add("onColor")

}



function changeSize(sid) {

    const color = document.getElementById(sid);

    const accordionItems = [...document.getElementsByClassName('size')]
    accordionItems.forEach(accordionItem => {
        accordionItem.classList.remove('onSize')
    })

    color.classList.add("onSize")

}




var cartOpen = false;
var numberOfProducts = 0;

$('body').on('click', '.js-toggle-cart', toggleCart);
$('body').on('click', '.js-add-product', addProduct);
$('body').on('click', '.js-remove-product', removeProduct);

function toggleCart(e) {
    e.preventDefault();
    if (cartOpen) {
        closeCart();
        return;
    }
    openCart();
}

function openCart() {
    cartOpen = true;
    $('body').addClass('open');
}

function closeCart() {
    cartOpen = false;
    $('body').removeClass('open');
}

function addProduct(e) {
    e.preventDefault();
    openCart();
    $('.js-cart-empty').addClass('hide');
    var product = $('.js-cart-product-template').html();
    $('.js-cart-products').prepend(product);
    numberOfProducts++;
}

function removeProduct(e) {
    e.preventDefault();
    numberOfProducts--;
    $(this).closest('.js-cart-product').hide(250);
    if (numberOfProducts == 0) {
        $('.js-cart-empty').removeClass('hide');
    }
}

////////
jQuery(document).ready(function ($) {
    var $owl = $('#owl-category');
    $owl.children().each(function (index) {
        jQuery(this).attr('data-position', index);
    });

    $owl.owlCarousel({
        loop: true,
        margin: 10,
        responsiveClass: true,
        responsive: {
            0: {
                items: 2,
                nav: true
            },
            600: {
                items: 2,
                nav: false
            },
            1000: {
                items: 5,
                nav: true,
                loop: false
            }
        }
    });
    $(document).on('click', '.item', function () {
        $owl.trigger('to.owl.carousel', $(this).data('position'));
    });
});

jQuery(document).ready(function ($) {
    var $owl = $('#owl-discount');
    $owl.children().each(function (index) {
        jQuery(this).attr('data-position', index);
    });

    $owl.owlCarousel({
        loop: true,
        margin: 10,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 1,
                nav: false
            },
            1000: {
                items: 1,
                nav: true,
                loop: false
            }
        }
    });
    $(document).on('click', '.item', function () {
        $owl.trigger('to.owl.carousel', $(this).data('position'));
    });
});


jQuery(document).ready(function ($) {
    var $owl = $('#owl-products');
    $owl.children().each(function (index) {
        jQuery(this).attr('data-position', index);
    });

    $owl.owlCarousel({
        loop: true,
        margin: 10,
        responsiveClass: true,
        responsive: {
            0: {
                items: 2,
                nav: true
            },
            600: {
                items: 1,
                nav: false
            },
            1000: {
                items: 5,
                nav: true,
                loop: false
            }
        }
    });
    $(document).on('click', '.item', function () {
        $owl.trigger('to.owl.carousel', $(this).data('position'));
    });
});

$(".profile-dropdown").hover(function () {

    $(".profile").addClass("show");
}, function () {
    $(".profile").removeClass("show");

})

$(".cart-dropdown").hover(function () {

    $("#cart").addClass("show");
}, function () {
    $("#cart").removeClass("show");

})




function addToCart(id) {

    console.log(id);



}