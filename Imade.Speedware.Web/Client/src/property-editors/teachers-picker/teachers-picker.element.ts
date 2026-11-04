import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-teachers-picker')
export class TeachersPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwareTeachersPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getTeachers({ throwOnError: true });
		return data.map((t) => ({ id: t.id, label: t.name }));
	}
}

export default TeachersPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-teachers-picker': TeachersPickerElement;
	}
}
