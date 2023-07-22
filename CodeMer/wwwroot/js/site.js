function openCase(evt, caseName) {
    let i, cases__btn_text_small, cases__content;

    cases__content = document.getElementsByClassName("cases__content");
    for (i = 0; i < cases__content.length; i++) {
        cases__content[i].style.display = "none";
    }

    cases__btn_text_small = document.getElementsByClassName("cases__btn text-small");
    for (i = 0; i < cases__btn_text_small.length; i++) {
        cases__btn_text_small[i].className = cases__btn_text_small[i].className.replace(" cases__btn--active", "");
    }
    
    document.getElementById(caseName).style.display = "block";
    evt.currentTarget.className += " cases__btn--active";
}

document.getElementById("defaultOpen").click()
