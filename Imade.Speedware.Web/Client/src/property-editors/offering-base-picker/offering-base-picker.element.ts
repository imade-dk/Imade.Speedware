import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-offering-base-picker')
export class OfferingBasePickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwareOfferingBasePicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getOfferingBases({ throwOnError: true });
		return data.map((o) => ({ id: o.id, label: o.name }));
	}
}

export default OfferingBasePickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-offering-base-picker': OfferingBasePickerElement;
	}
}
