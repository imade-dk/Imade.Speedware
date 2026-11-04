import { manifests as teachersPicker } from './teachers-picker/manifest.js';
import { manifests as playTeachersPicker } from './play-teachers-picker/manifest.js';
import { manifests as roomsPicker } from './rooms-picker/manifest.js';
import { manifests as schoolsPicker } from './schools-picker/manifest.js';
import { manifests as publishingTypesPicker } from './publishing-types-picker/manifest.js';

export const manifests = [
	...teachersPicker,
	...playTeachersPicker,
	...roomsPicker,
	...schoolsPicker,
	...publishingTypesPicker,
];
