jQuery(document).ready(function() {
    "use strict";

    /*=================== Responsive Button Menu And Links Slide In ===================*/
    $(".responsive-bar span").on("click", function(e) {
        var target = $(e.target);
        var data_menu = $(e.target.attributes['data-target']).val();
        if (target.is('.open-menu') || data_menu == 'menu') {
            $(".responsive-links.other").removeClass("slidein");
            $(".responsive-links.menu").toggleClass("slidein");
        }
        if (target.is('.open-links') || data_menu == 'links') {
            $(".responsive-links.menu").removeClass("slidein");
            $(".responsive-links.other").toggleClass("slidein");
        }
    });


    $("html").on("click", function() {
        $(".responsive-links.other").removeClass("slidein");
        $(".responsive-links.menu").removeClass("slidein");
    });

    $(".responsive-header").on("click", function(e) {
        e.stopPropagation();
    })




    /*=================== Responsive Menu And Links Dropdown ===================*/
    $(".responsive-links ul li.menu-item-has-children > a").on("click", function() {
        $(this).parent().siblings().find("ul").slideUp();
        $(this).next("ul").slideToggle();
        return false;
    });
    $(".responsive-links ul li .lang-selector span").on("click", function() {
        $(this).next("ul").slideToggle();
        return false;
    })


    /*=================== Language Selector ===================*/
    $(".lang-selector li span").on("click", function() {
        var language = $(this).html();
        $(".lang-selector > span").html(language);
    })


    /*=================== Cart Page Remove Item ===================*/
    $(".remove-item").on("click", function() {
        $(this).parent().slideUp();
    });



    /*=================== Fixed Sidebar Functionalities ===================*/
    /*=== Fixed Sidebar Scrollbar ===*/
    $('.fixed-sidebar, .responsive-links').enscroll({
        showOnHover: false,
        verticalTrackClass: 'track3',
        verticalHandleClass: 'handle3'
    });


    /*=== Add Stick On Scroll ===*/
    $(window).scroll(function() {
        var scroll = $(window).scrollTop();
        if (scroll >= 70) {
            $(".fixed-sidebar, .sidebar-toggle.c-hamburger").addClass("stick");
        } else {
            $(".fixed-sidebar, .sidebar-toggle.c-hamburger").removeClass("stick");
        }
    });


    /*=================== Wishlist Button Active On Scroll ===================*/
    $(window).scroll(function() {
        var scroll = $(window).scrollTop();
        if (scroll >= 500) {
            $(".wishlist-btn").addClass("active");
        } else {
            $(".wishlist-btn").removeClass("active");
        }
    });


    /*=== Set Gap According to Screen ===*/
    var header_height = $("header").innerHeight();
    var responsive_header = $(".responsive-header").innerHeight();
    var right_gap = $(".container").offset().left;

    $(".fixed-sidebar").css({
        "right": right_gap,
        "margin-top": header_height
    });
    $(".sidebar-toggle.c-hamburger").css({
        "margin-top": header_height
    });

    if (($(window).width()) < 980) {
        $(".sidebar-toggle.c-hamburger,.fixed-sidebar").css({
            "margin-top": responsive_header
        });
    }

    $(".sidebar-toggle.c-hamburger").on("click", function() {
        $(".fixed-sidebar").toggleClass("slide");
        return false;
    })



    /*=================== Account Detail Page Profile Information Change ===================*/
    $(".profile-info div a.change").on("click", function() {
        $(this).next("form").slideToggle().toggleClass("slided");
        var title = $(this).data('title');
        var chng = $(this).data('change');

        if ($(this).next("form").hasClass("slided")) {
            $(this).html(chng);
        } else {
            $(this).html(title);
        }
        return false;
    });


    /*=================== Filters Dropdowns ===================*/
    $(".size").on("click", function() {
        $(".size").removeClass("active");
        $(this).addClass("active");
    });
    $(".search-tools > ul > li > a").on("click",function(){return false;})

    var drop = $(".search-tools > ul > li");
    $(".search-tools > ul > li").each(function() {
        var delay = 0;
        $(".search-tools").find(drop).each(function() {
            $(this).css({
                transitionDelay: delay + 'ms'
            });
            delay += 70;
        });
    });



    /*=================== Three & Four Column Switcher ===================*/
    $(".three-col").on("click", function() {
        $(".images-list").find(".col-md-3").each(function() {
            $(this).attr("class", "col-md-4");
        });
        return false;
    })

    $(".four-col").on("click", function() {
        $(".images-list").find(".col-md-4").each(function() {
            $(this).attr("class", "col-md-3");
        });
        return false;
    })


    $(".next > a").on("click", function() {
        var div_name = $(this).parent().prev("div").attr("class");
        setTimeout(function() {
            var div_added = document.getElementsByClassName(div_name);
            $(".added").attr("class", div_name);
        }, 2000);
    });


    /*=================== Registration and Packages Popups ===================*/
    $(".call-reg").on("click", function() {
        $(".registration-popup").fadeIn();
        $("html,body").addClass("stop");
        if ($(this).hasClass("signup-popup")) {
            $(".form-box.login-popup").slideUp();
            $(".form-box.signup-popup").slideDown();
        } else if ($(this).hasClass("login-popup")) {
            $(".form-box.signup-popup").slideUp();
            $(".form-box.login-popup").slideDown();
        }
        return false;
    });

    $(".package-btn").on("click", function() {
        $(".registration-popup").fadeIn();
        $(".packages-popup").slideDown();
        $("html,body").addClass("stop");
        return false;
    })



    $("html,.popup-container span.close-popup").on("click", function() {
        $("html,body").removeClass("stop");
        $(".form-box.login-popup").slideUp();
        $(".form-box.signup-popup").slideUp();
        $(".packages-popup").slideUp();
        $(".registration-popup").fadeOut();
    });

    $(".form-box, .packages-popup").on("click", function(e) {
        e.stopPropagation();
    })




    /*=================== Custom Tabs Functionality ===================*/
    $(".tab-detail").fadeOut();
    $(".tab-detail.active").fadeIn();

    $(".custom-tabs li a").on("click", function() {
        $(this).parent().parent().find("li").removeClass("active");
        $(this).parent().addClass("active");
        $(".tab-detail").slideUp().removeClass("active");
        var tab_name = $(this).data("name");
        $(".custom-content .tab-detail").each(function() {
            if ($(this).data("id") == tab_name) {
                $(this).slideDown().addClass("active");
            }
        });
        return false;
    });


    /*=================== Site Info Bar Height ===================*/
    var site_bar = $(".site-info-bar").innerHeight();
    $(".welcome-overlay").css({
        "padding-bottom": site_bar
    });



    /*=================== Set Height ===================*/
    function thirty_pc() {
        var height = $(window).height();
        var thirtypc = (100 * height) / 100;
        thirtypc = parseInt(thirtypc, 10) + 'px';
        $(".main-slider #layerslider").css('height', thirtypc);
    }
    $(document).ready(function() {
        thirty_pc();
        $(window).bind('resize', thirty_pc);

    });


    $('.parallax').scrolly({
        bgParallax: true
    });


}); /*=== Document.Ready Ends Here ===*/

