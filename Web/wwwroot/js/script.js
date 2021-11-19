let search = document.querySelector(".search")
let btn = document.querySelector(".btn")
let input = document.querySelector(".input")

btn.addEventListener('click', () => {
    search.classList.toggle('active');
    input.focus()
})




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
    var $owl = $('.owl-carousel');
    $owl.children().each(function (index) {
        jQuery(this).attr('data-position', index);
    });

    $owl.owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 3
            },
            1000: {
                items: 5
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