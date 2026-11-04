import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-schools-picker')
export class SchoolsPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwareSchoolsPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getSchools({ throwOnError: true });
		return data.map((s) => ({ id: s.id, label: s.name }));
	}
}

export default SchoolsPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-schools-picker': SchoolsPickerElement;
	}
}
