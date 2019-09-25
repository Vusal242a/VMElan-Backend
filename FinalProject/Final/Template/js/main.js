$(document).ready(function () {
    $('.nav-switch').on('click', function () {
        $('.nav-top').toggleClass("show");
    })
})


$('#accordion a').on('click' ,function(){
    if ($(this).hasClass("collapsed")) {
        $(this).find('i').css({'transform':'rotate(180deg)'});
        console.log("hello it is me");
    }
    else {
        $(this).find('i').css({'transform':'rotate(0deg)'});
    }
})
$(document).ready(function () {
    $('ul.pagination li a').on('click',function(){
        $('ul.pagination li a.passive').removeClass("passive");
        $(this).addClass("active");
    })
})
