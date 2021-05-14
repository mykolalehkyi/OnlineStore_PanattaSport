/// <binding AfterBuild='default' />
let gulp = require('gulp');
let gulp_ts = require('gulp-typescript');

let filePaths = {
    tsInputPath: "./TypeScript/**/*.ts",
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

exports.default = gulp.series('build-ts');