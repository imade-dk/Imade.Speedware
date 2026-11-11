import { manifests as teachersPicker } from './teachers-picker/manifest.js';
import { manifests as playTeachersPicker } from './play-teachers-picker/manifest.js';
import { manifests as roomsPicker } from './rooms-picker/manifest.js';
import { manifests as schoolsPicker } from './schools-picker/manifest.js';
import { manifests as publishingTypesPicker } from './publishing-types-picker/manifest.js';
import { manifests as bookingTypesPicker } from './booking-types-picker/manifest.js';
import { manifests as playBookingTypesPicker } from './play-booking-types-picker/manifest.js';
import { manifests as offeringBasePicker } from './offering-base-picker/manifest.js';
import { manifests as coursesPicker } from './courses-picker/manifest.js';
import { manifests as coursesTreePicker } from './courses-tree-picker/manifest.js';

export const manifests = [
	...teachersPicker,
	...playTeachersPicker,
	...roomsPicker,
	...schoolsPicker,
	...publishingTypesPicker,
	...bookingTypesPicker,
	...playBookingTypesPicker,
	...offeringBasePicker,
	...coursesPicker,
	...coursesTreePicker,
];
