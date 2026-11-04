import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-courses-picker')
export class CoursesPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwareCoursesPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getCourses({ throwOnError: true });
		return data.map((c) => ({ id: c.id, label: c.name }));
	}
}

export default CoursesPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-courses-picker': CoursesPickerElement;
	}
}
