import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-play-teachers-picker')
export class PlayTeachersPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwarePlayTeachersPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getPlayTeachers({ throwOnError: true });
		return data.map((t) => ({ id: t.id, label: t.name }));
	}
}

export default PlayTeachersPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-play-teachers-picker': PlayTeachersPickerElement;
	}
}
