﻿$(function () {

    $(".accordion-group>a").click(function () {
        if ($(this).nextAll(".accordion-inner").hasClass("active")) {
            return false;
        }
        $(this).parents("ul").find(".accordion-inner.active").removeClass("active").hide(200);
        $(this).nextAll(".accordion-inner").addClass("active").show(200);
        return false;
    });
    var mainContainer = $("#main-body");
    $(window).resize(function () {
        mainContainer.height($(window).height() - 100);
    });
    mainContainer.height($(window).height() - 100);


    $(document).on("click", ".cancel", function () {
        window.history.back();
    }).on("click", ".publish", function () {
        if (confirm("确认要发布吗？")) {
            return true;
        }
        return false;
    }).on("click", "input[type=submit]", function () {
        $("#ActionType").val($(this).data("value"));
        return true;
    }).on("click", ".input-group-collection .add", function () {
        var index = $(this).siblings(".items").children(".item").size();
        var namePrefix = $(this).data("name-prefex");
        var template = $($(this).siblings(".Template").html());
        $("input,select,area", template).attr("data-val", true).each(function () {
            var name = $(this).attr("name");
            if (name) {
                $(this).attr("name", name.replace(namePrefix, namePrefix + "[" + index + "]"));
            }
        });
        template.find(".ActionType").val($(this).data("value"));
        $(this).siblings(".items").append(template);
    }).on("click", ".input-group-collection .delete", function () {
        $(this).parent().hide();
        $(this).siblings(".hide").find(".ActionType").val($(this).data("value"));
    }).on("click", ".input-group .glyphicon.glyphicon-search", function () {
        var obj = $(this);
        window.top.Easy.ShowUrlWindow({
            url: obj.parent().siblings("input.form-control").data("url"),
            onLoad: function (box) {
                var win = this;
                $(this.document).find("#confirm").click(function () {
                    var target = obj.parent().siblings("input.form-control");
                    target.val(win.GetSelected());
                    box.close();
                });
                $(this.document).on("click", ".confirm", function () {
                    var target = obj.parent().siblings("input.form-control");
                    target.val($(this).data("result"));
                    box.close();
                });
            }
        });
    }).on("click", ".form-group select#ZoneID", function () {
        var obj = $(this);
        var url = "/admin/Layout/SelectZone?layoutId=" + $(".hide #LayoutID").val() + "&pageId=" + $(".hide #PageID").val() + "&zoneId=" + obj.val();
        window.top.Easy.ShowUrlWindow({
            url: url,
            width: 1000,
            title: "选择区域",
            onLoad: function (box) {
                var win = this;
                $(this.document).find("#confirm").click(function () {
                    obj.val(win.GetSelected());
                    box.close();
                });
            }
        });
    });
    $(".form-group select#ZoneID").on("mousedown", false);

    var mainMenu = $("#main-menu");
    var currentSelect;
    var match = 0;
    $("a.menu-item", mainMenu).each(function () {
        var href = $(this).attr("href");
        if (href) {
            if (location.pathname.toLocaleLowerCase().indexOf(href.toLowerCase()) === 0) {
                if (href.length > match) {
                    currentSelect = $(this);
                    match = href.length;
                }
            }
        }
    });
    if (currentSelect && currentSelect.size()) {
        currentSelect.addClass("active");
        if (currentSelect.parent().hasClass("accordion-inner")) {
            currentSelect.parent().show();
            currentSelect.parent().prev().addClass("active");
        }
    }


    $(".Date").each(function () {
        $(this).datetimepicker({ locale: "zh_cn", format: $(this).attr("JsDateFormat") });
    });
    $(document).on("click", ".nav.nav-tabs a", function () {
        $(this).tab('show');
        return false;
    });
    $('.nav.nav-tabs').each(function () {
        var shown = false;
        $("li", this).each(function () {
            if ($(this).hasClass("active")) {
                $(this).removeClass("active");
                $("a", this).tab("show");
                shown = true;
            }
        });
        if (!shown) {
            $("li:first a", this).tab("show");
            if (location.hash) {
                $("li a[href='" + location.hash + "']", this).tab("show");
            }
        }
    });

    $('#StyleClass.form-control').popover({
        trigger: "focus",
        html: true,
        title: "自定义样式用法",
        content: function () {
            var activeClass = [
                { name: "边框", value: "border" },
                { name: "文字居中", value: "align-center" },
                { name: "文字右对齐", value: "align-right" },
                { name: "图片边框", value: "image-border" },
                { name: "阴影", value: "box-shadow" },
                 { name: "图片圆形", value: "image-circle" }
            ];
            var html = "<p clss='text-nowrap'>直接写样式例：<code>style=\"color:#fff\"</code></p><p>预定义样式：<ol>";
            for (var i = 0; i < activeClass.length; i++) {
                html += "<li>" + activeClass[i].name + ":<code>" + activeClass[i].value + "</code></li>";
            }
            html += "</ol></p>";
            return html;
        },
        placement: "bottom"
    });



    $("input.select-image").popover({
        trigger: "focus",
        html: true,
        title: "图片预览",
        content: function () {
            var url = $(this).val();
            if (url) {
                if (url.indexOf("~") === 0) {
                    url = url.replace("~", location.origin);
                }
                return "<div style='width:245px;'><img src='" + url + "'/></div>";
            }
            return null;
        },
        placement: "bottom"
    });

    tinymce.init({
        content_css: ["../../../Content/bootstrap/css/bootstrap.css", "../../../Content/bootstrap/css/bootstrap-theme.css"],
        selector: "textarea.html",
        plugins: [
            "advlist autolink lists link image charmap print preview anchor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste"
        ],
        toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image",
        height: 300,
        relative_urls: false,
        language: "zh_CN"
    });
});