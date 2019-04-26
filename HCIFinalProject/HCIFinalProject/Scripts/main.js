var toggleMenuTree = function() {
    treeToggle = document.getElementById('tree-toggle');
    menuTree = document.getElementById('menu-tree');
    mainContent = document.getElementById('search-results');
    treeToggle.classList.toggle("open-tree");
    menuTree.classList.toggle("open-tree");
    mainContent.classList.toggle('open-tree');
}

function changeNavigation() {
    
    var tabs = ["doors", "inserts", "frames", "hardware"];
    var url = document.URL.split('/');
    try {
        oldActiveNav = document.getElementsByClassName("active");
        for (i = 0; i < oldActiveNav.length; i++) {
            oldActiveNav[i].classList.toggle("active")
        }
    }
    catch(err){

    }
    if (url.length >= 5) {
        for (i = 0; i < tabs.length; i++) {
            console.log(url[4].toLowerCase());
            if (url[4].toLowerCase().startsWith(tabs[i])) 
                document.getElementById(tabs[i]).classList.toggle("active")
        }
    }
    else {
        document.getElementById("doors").classList.toggle("active")
    }

}

var onclick = function(){
    var x = document.URL.split('#');
    x.forEach(element => {
        console.log(element);
    });   
}

var renderSearch = function() {
    searchField = document.getElementById('searchbox');
    document.getElementById('search-form').action = '#' + encodeURI(searchField.value);
    searchField.value = '';
}

// https://www.w3schools.com/howto/howto_js_list_grid_view.asp
var elements = document.getElementsByClassName("searchItemCol");
var i;
function listView(){
    for (i = 0; i < elements.length; i++) {
        elements[i].style.width = "100%";
        }
}

function gridView() {
    if (document.documentElement.clientWidth > 1300)
        for (i = 0; i < elements.length; i++) {
                elements[i].style.width = "50%";
        }
}

var container = document.getElementById("top-row-results");
var btns = container.getElementsByClassName("btn");
for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click", function() {
        var current = document.getElementsByClassName("activeBtn");
        current[0].className = current[0].className.replace(" activeBtn", "");
        this.className += " activeBtn";
        });
}

// Interseting search tags and re-rendering movies that have a match
var renderTags = function () {
    searchField = document.getElementById('tag-input');
    filterTags = document.getElementsByClassName('bootstrap-tagsinput')[0];
    var oldstr = filterTags.innerHTML;
    filterTags.innerHTML = "<span id='tags' class='tag label label-info'>" + searchField.value + "<span onclick=\"removeTag('str', this)\" data-role='remove'></span></span>" + oldstr;
    searchField.value = '';
    renderTagFilter();
}

// that contains the tag strings word.
var renderTagFilter = function () {
    var tags = document.getElementsByClassName('label-info');
    var newestTag = tags[0];

    for (i = 0; i < tags.length; i++) {
        if (i != 0) {
            if (tags[i].textContent.toLowerCase() == newestTag.textContent.toLowerCase()) {
                newestTag.remove();
            }
        }
    };
}

var removeTag = function (string, tag) {
    $(tag).parent().remove();
    renderTagFilter();
}

var applyFilter  = function() {
    var tags = document.getElementsByClassName("tag");
    var priceRang = document.getElementsByClassName("price-select");
    var dims = document.getElementsByClassName("dimension");
    var dims2 = document.getElementsByClassName("dimension1");
    var numbers = document.getElementsByClassName("lites-select");

    var urlStr = "?tags=";

    Array.from(tags).forEach((tag) => {
        urlStr +=":"+ tag.textContent;
    });
    urlStr += "&priceRange=";
    Array.from(priceRang).forEach((tag) => {
        urlStr += tag.value;
    });
    urlStr += "&dim1=";
    Array.from(dims).forEach((tag) => {
        urlStr += ":" + tag.value;
    });
    urlStr += "&dim2=";
    Array.from(dims2).forEach((tag) => {
        urlStr += ":" + tag.value;
    });
    urlStr += "&num=";
    Array.from(numbers).forEach((tag) => {
        urlStr += ":" + tag.value;
    });

    window.location.href = encodeURI(urlStr.replace(/(\r\n|\n|\r)/gm, ""));
}