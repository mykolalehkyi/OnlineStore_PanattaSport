/// <binding AfterBuild='default' />
let gulp = require('gulp');
let gulp_ts = require('gulp-typescript');

let filePaths = {
    tsInputPath: "./wwwroot/**/*.ts",
    tsOutputPath: "./wwwroot/js"
};

gulp.task('build-ts', () => {
    return gulp.src(filePaths.tsInputPath)
        .pipe(gulp_ts({
            "module": "es2015",
            "target": "es2015",
            "sourceMap": true,
            "moduleResolution": "classic"
        }))
        .pipe(gulp.dest(filePaths.tsOutputPath));
})

//exports.default = gulp.series('build-ts');

//"devDependencies": {
//    "@types/datatables.net": "^1.10.19",
//        "@types/jquery": "^3.5.5",
//            "@types/node": "^15.0.3",
//                "@types/toastr": "^2.1.38",
//                    "g": "^2.0.1",
//                        "npm": "^7.12.1",
//                            "gulp": "*",
//                                "gulp-typescript": "*",
//                                    "sweetalert2": "^10.16.7",
//                                        "typescript": "*"
//}

    //,
    //"wwwroot"