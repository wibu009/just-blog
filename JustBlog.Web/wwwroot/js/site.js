// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function isNullOrEmpty(s) {
    if (s == undefined || s == null || s.length == '') {
        return true;
    }
    return false;
}

function getCategoriesDropDown() {
    let categoriesDropDown = document.getElementById('categories-dropdown-partial-view');
    if (categoriesDropDown != null) {
        fetch('/category/partialview/categoriesDropdown').then(re => re.text()).then(partialView => categoriesDropDown.innerHTML = partialView);
    }
}

function getAboutCard() {
    let aboutCard = document.getElementById('about-card-partial-view');
    if (aboutCard != null) {
        fetch('/post/aboutcard').then(re => re.text()).then(partialView => aboutCard.innerHTML += partialView);
    }
}

function getLatestPosts() {
    let latestPosts = document.getElementById('latest-posts-partial-view');
    if (latestPosts != null) {
        fetch('/post/latestposts').then(re => re.text()).then(partialView => latestPosts.innerHTML += partialView);
    }
}

function getMostViewedPosts() {
    let mostViewedPosts = document.getElementById('most-viewed-posts-partial-view');
    if (mostViewedPosts != null) {
        fetch('/post/mostviewedposts').then(re => re.text()).then(partialView => mostViewedPosts.innerHTML += partialView);
    }
}

function getPopularTags() {
    let popularTags = document.getElementById('popular-tags-partial-view');
    if (popularTags != null) {
        fetch('/tag/partialview/populartags').then(re => re.text()).then(partialView => popularTags.innerHTML += partialView);
    }
}

function getCommentsByPost() {
    let commentsBox = document.getElementById('comments-box');
    if (commentsBox != null) {
        let postId = document.getElementById('postId').value;
        fetch(`/comment/CommentsByPosts/${postId}`).then(re => re.text()).then(partialView => commentsBox.innerHTML = partialView);
    }
}

function getDataTable(controller, action, page, pageSize) {
    let dataTable = document.getElementById('data-table');
    if (dataTable != null) {
        fetch(`/admin/${controller}/${action}?page=${page}&pageSize=${pageSize}`).then(re => re.text()).then(partialView => dataTable.innerHTML = partialView);
    }
}

$('#submit-comment-btn').on('click', function () {
    let comment = {
        postId: $('#postId').val(),
        commentHeader: $('#comment-header').val(),
        name: $('#comment-name').val(),
        email: $('#comment-email').val(),
        commentText: $('#comment-text').val()
    }
    if (isNullOrEmpty(comment.commentHeader) || isNullOrEmpty(comment.name) || isNullOrEmpty(comment.email) || isNullOrEmpty(comment.commentText)) {
        alert('Name, Email and comment text must be not empty');
    }
    else {
        $.ajax({
            url: '/comment/AddComment',
            type: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify({
                postId: $('#postId').val(),
                commentHeader: $('#comment-header').val(),
                name: $('#comment-name').val(),
                email: $('#comment-email').val(),
                commentText: $('#comment-text').val()
            })
        }).done(function () {
            $('#comment-header').val('');
            $('#comment-name').val('');
            $('#comment-email').val('');
            $('#comment-text').val('');
            getCommentsByPost();
            alert('Add comment success!');
        });
    }
});

function deleteRecord(id, controller, action, page, pageSize) {
    fetch(`/admin/${controller}/delete/${id}`, {
        method: 'delete'
    }).then(re => re).then(re => {
        if (re.url.includes('auth'))
            window.location.href = re.url;
        else
            getDataTable(controller, action, page, pageSize);
    });
}

function getSlug(name) {
    var slug = name.toLowerCase()
        .replaceAll('đ', 'd')
        .replace(/[àáảãạâầấẩẫậăằắẳẵặ]/gm, 'a')
        .replace(/[éẻẽẹêềếểễệ]/gm, 'e')
        .replace(/[ìíỉĩị]/gm, 'i')
        .replace(/[òóỏõọôồốổỗộơờớởỡợ]/gm, 'o')
        .replace(/[ùúủũụưừứửữự]/gm, 'u')
        .replace(/[^A-z\d]+/gm, '-')
        .replace(/^\-|\-$/gm, '');
    document.getElementById('UrlSlug').value = slug;
}
let name = document.getElementById('Name');
if (name != null) {
    name.addEventListener('input', function () {
        getSlug(this.value);
    });
}

getCategoriesDropDown();
getCommentsByPost();
getAboutCard();
getLatestPosts();
getMostViewedPosts();
getPopularTags();

let controller = document.getElementById('controller');
if (controller != null) {
    action = document.getElementById('action');
    getDataTable(controller.value, action.value, 1, 10);
}

$("#PostContent").ckeditor();
$("#ShortDescription").ckeditor();
$("#Description").ckeditor();
$("#CommentText").ckeditor();